using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginBackend.model;

[Table("Books")]
public class Book
{
    public Book(string name, string author)
    {
        Name = name;
        Author = author;
        
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String Uuid { get; set; }
    public String Name { get; set; }
    public String Author { get; set; } 
    public ICollection<User> Users { get; } = new List<User>();
    
    
}