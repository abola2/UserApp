using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginBackend.model;

[Table("Users")]
public class User
{
    public User(string name, Byte[] password, Byte[] hash)
    {
        Name = name;
        Password = password;
        Hash = hash;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String? Uuid { get; set; }
    [Required]
    public String Name { get; set; }
    [Required]
    public Byte[] Password { get; set; } 
    
    [Required]
    public Byte[] Hash { get; set; } 
    public SessionToken? SessionToken { get; set; }
    public ICollection<Book> Books { get; } = new List<Book>();
    
    
}