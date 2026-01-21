using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginBackend.model;

[Table("Users")]
public class User(string name, Byte[] password, Byte[] hash)
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String? Uuid { get; set; }
    [Required]
    public String Name { get; set; } = name;

    [Required]
    public Byte[] Password { get; set; } = password;

    [Required]
    public Byte[] Hash { get; set; } = hash;

    public SessionToken? SessionToken { get; set; }
    public ICollection<Book> Books { get; } = new List<Book>();
    
    
}