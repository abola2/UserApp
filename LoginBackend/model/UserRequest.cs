namespace LoginBackend.model;

public class UserRequest
{
    public UserRequest(string name, string password)
    {
        Name = name;
        Password = password;
    }
    
    public String Name { get; set; }
    public String Password { get; set; } 
}