using eCommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace eCommerceWebApi.DataAccess
{


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        public DbSet<User> Users { get; set; }
    }
}