namespace ConsoleApp1.model;

public class User
{
    public User(string name, string password)
    {
        this.name = name;
        this.password = password;
        this.uuid = Guid.NewGuid().ToString();
    }

    private String name;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Uuid
    {
        get => uuid;
        set => uuid = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => password;
        set => password = value ?? throw new ArgumentNullException(nameof(value));
    }

    private String uuid;
    private String password;
    
    
}