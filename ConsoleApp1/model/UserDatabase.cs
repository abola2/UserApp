using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.model;

public class UserDatabase : DbContext
{
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=app.db");
}