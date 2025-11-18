using Microsoft.EntityFrameworkCore;
using Lab0.Models;

namespace Lab0.Models;

public class AddDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }    // najrpostrzy sosób na dostanie się do kolekjci zawartej w bazie danych
    public DbSet<Organization> Organizations { get; set; }  // dodajemy to po uwtorzeniu OrganizationController.cs
    // teraz nadpisujemy dwie metody robimy: ctrl + o 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=d:\data\Contacts-gr1.db");     //sqlight musi utworzyć sobie plik z bazą
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasData(
                new Contact()
                {
                    Id = 1,
                    Email = "adam@wsei.edu.pl",
                    Name = "Adam",
                },
                new Contact()
                {
                    Id = 2,
                    Email = "ewa@wsei.edu.pl",
                    Name = "Ewa"
                },
                new Contact()
                {
                    Id = 3,
                    Email = "karol@wsei.edu.pl",
                    Name = "Karol"
                }
                
                ); // czyta dane z bazy 
        
        
        modelBuilder.Entity<Organization>()     // od tego momentu wszystko co pod spodem jest dodane po utworzeniu OrganizationController.cs
            .HasData(
                new Organization()
                {
                    Id = 101,
                    Name = "WSEI",
                    Address = "Św. Filipa 17, Kraków",
                },
                new Organization()
                {
                    Id = 102,
                    Name = "PKP",
                    Address = "Polska"
                },
                new Organization()
                {
                    Id = 103,
                    Name = "GUGU",
                    Address = "Lipowa 15"
                }
                
            ); // czyta dane z bazy 
        
    }

public DbSet<Lab0.Models.Organization> Organization { get; set; } = default!;
}