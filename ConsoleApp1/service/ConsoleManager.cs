using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class ConsoleManager
{
    
    
    private Dictionary<String, User> _users = new Dictionary<String, User>();

    public void ReadUserInput()
    {
        using var db = new UserDatabase();

        while (true)
        {
            Console.WriteLine("Whats your name?");
            String? name = Console.ReadLine();

            if (_users.Values.Select(x => x.Name).Contains(name))
            {
                Console.WriteLine("That name is already taken.");
                continue;
            }
            
            Console.WriteLine($"Hello {name}, what's your password?");
            String ?password = Console.ReadLine();
            User user = new User(name, password);
            db.Add(user);
            db.SaveChanges();
            Console.WriteLine("User saved!");    
        }
        
    }


    private void Login()
    {
        
    }
    
    
    
}