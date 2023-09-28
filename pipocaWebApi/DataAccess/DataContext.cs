using System.Configuration;
using Microsoft.EntityFrameworkCore;
using pipocaWebApi;
public partial class DataContext : DbContext
{

    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{    
     if (!optionsBuilder.IsConfigured){            
             var connectionString = Configuration.GetConnectionString("Default");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
     }
   
}

 public DbSet<User> Users { get; set; }
 public DbSet<Conteudo> Conteudos { get; set; }


}