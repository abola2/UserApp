using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.model;

public class UserDatabase : DbContext
{
    
    private static UserDatabase _instance;

    // Lock object for thread safety
    private static readonly object _lock = new();

    private UserDatabase()
    {
        Console.WriteLine("UserDatabase initialized.");
    }

    public static UserDatabase Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UserDatabase();
                }
                return _instance;
            }
        }
    }
    
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Book> Books { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=app.db");
}