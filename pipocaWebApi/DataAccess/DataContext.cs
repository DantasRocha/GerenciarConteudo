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
             string? connectionString = Configuration.GetConnectionString("Default");
            optionsBuilder.UseMySQL(connectionString);
     }
   
}

 public DbSet<User> Users { get; set; }
 public DbSet<Conteudo> Conteudos { get; set; }


}