using Microsoft.EntityFrameworkCore;
using WebApp.Models.Services;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath { get; set; }


    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowalski",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "adad@gmail.com",
                    PhoneNumber = "123456234",
                    Created = DateTime.Now
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Robert",
                    LastName = "Kowal",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "robert@gmail.com",
                    PhoneNumber = "123742684",
                    Created = DateTime.Now
                },
                new ContactEntity()
                {
                    Id = 3,
                    FirstName = "Robert",
                    LastName = "Kowal",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "robert@gmail.com",
                    PhoneNumber = "124963748",
                    Created = DateTime.Now
                }
            );
    }
}