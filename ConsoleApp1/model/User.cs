using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.model;

[Table("Users")]
public class User
{
    public User(string name = null, string password = null)
    {
        Name = name;
        Password = password;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String? Uuid { get; set; }
    [Required]
    public String Name { get; set; }
    [Required]
    public String Password { get; set; } 
    public ICollection<Book> Books { get; } = new List<Book>();
    
    
}