using Microsoft.EntityFrameworkCore;

namespace LoginBackend.model;

public class UserDatabase : DbContext
{
    public string DbPath { get; }
    
    public UserDatabase()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "loginbackend.db");
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Book> Books { get; set; }
    
    public DbSet<SessionToken> SessionTokens { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}