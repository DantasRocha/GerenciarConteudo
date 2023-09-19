

using Microsoft.EntityFrameworkCore;
using eCommerceWebApi.Models;
using System.Globalization;


public class DataContext2 : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext2(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("Default");
        //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<User> Users { get; set; }
}
