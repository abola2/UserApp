using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.model;

public class UserDatabase : DbContext
{
    
    public DbSet<User> Users { get; set; }
    
    public string DbPath { get; set; }

    public UserDatabase()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "user.db");
    }
    

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}