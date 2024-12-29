using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.model;

public class User
{
    public User(string name = null, string password = null)
    {
        Name = name;
        Password = password;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String Uuid { get; set; }
    public String Name { get; set; }
    public String Password { get; set; } 
    
    
}