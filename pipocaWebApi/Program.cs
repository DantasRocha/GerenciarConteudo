using eCommerceWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
//using MySql.Data.MySqlClient;
//using MySql.EntityFrameworkCore.Extensions;

//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using Pomelo.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


 builder.Services.AddEntityFrameworkMySQL().AddDbContext < DataContext > (options => {
     options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
  });






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
