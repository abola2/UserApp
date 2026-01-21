using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginBackend.model;

[Table("Books")]
public class Book(string name, string author)
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String Uuid { get; set; }
    public String Name { get; set; } = name;
    public String Author { get; set; } = author;
    public ICollection<User> Users { get; } = new List<User>();
    
    
}