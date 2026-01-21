namespace LoginBackend.model;

public class UserRequest(string name, string password)
{
    public String Name { get; set; } = name;
    public String Password { get; set; } = password;
}