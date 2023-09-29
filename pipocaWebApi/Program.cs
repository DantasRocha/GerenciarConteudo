using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore.Extensions;
using MySql.EntityFrameworkCore.Infrastructure;
using pipocaWebApi;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


void ConfigureServices2(IServiceCollection services)
{
    
    string? connectionString = builder.Configuration.GetConnectionString("Default");
    MySqlConnection connection = new MySqlConnection(connectionString);
    services.AddTransient<MySqlConnection>(_ => connection);
    services.AddDbContext<DataContext>(options => {
      options.UseMySQL(connection);
    });
}


void ConfigureServices(IServiceCollection services)
{
    string? connectionString = builder.Configuration.GetConnectionString("Default");
    MySqlConnection connection = new MySqlConnection(connectionString);
    services.AddTransient<MySqlConnection>(_ => connection);
    services.AddEntityFrameworkMySQL().AddDbContext < DataContext > (options => {
    options.UseMySQL(connection);
  });
}

void ConfigureServices7(IServiceCollection services)
{
    services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration["ConnectionStrings:planetscale"]));
}



// void ConfigureServices3(IServiceCollection services){
//             string? connectionString = builder.Configuration.GetConnectionString("Default");
//             MySqlConnection connection = new(connectionString);
//             builder.Services.AddDbContext<DataContext>(
//                 options =>
//                     options.UseMySQL(
//                         connection,
//                         ServerVersion.AutoDetect(connectionString),
//                         ServerOptions =>
//                         ServerOptions.MigrationsHistoryTable(
//                             tableName: HistoryRepository.DefaultTableName,
//                             schema: "asp")
//                         .SchemaBehavior(
//                             (Pomelo.EntityFrameworkCore.MySql.Infrastructure.MySqlSchemaBehavior)MySqlSchemaBehavior.Translate,
//                             (schema, table) => $"{schema}_{table}")
//             ));

// }
//  builder.Services.AddEntityFrameworkMySQL().AddDbContext < DataContext > (options => {
//      options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
//   });


// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<DataContext>(options =>
// {
//     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));    
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
