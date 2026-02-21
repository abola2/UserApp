using Microsoft.EntityFrameworkCore;

namespace LoginBackend.model;

public class UserDatabase : DbContext
{
    
    public UserDatabase(DbContextOptions<UserDatabase> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Book> Books { get; set; }
    
    public DbSet<SessionToken> SessionTokens { get; set; }

}