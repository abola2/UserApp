using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.model;


[Table("SessionToken")]
public class SessionToken
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Key]
    public String SessionTokenId { get; set; }
    
    public String Token { get; set; }

    [ForeignKey(nameof(User))]
    public String? Uuid { get; set; }
    
    public User? User { get; set; }
    
    public DateTimeOffset ExpirationDate { get; set; }
}