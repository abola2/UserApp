using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class UserSerivce : IUserService
{

    private readonly UserDatabase _userDatabase;
    
    public UserSerivce(UserDatabase userDatabase)
    {
        _userDatabase = userDatabase;
    }


    public bool AlreadyExist(String name)
    {
        return _userDatabase.Users.Any(u => u.Name == name);
    }
    

    public User AddUser()
    {
        
        
        
        
        bool invalidName = true;
        String? userName = "";
        while (invalidName)
        {
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            if ( !string.IsNullOrEmpty(userName) && !AlreadyExist(userName))
            {
                invalidName = false;
            }            
        }
        Console.WriteLine("What is your password?");
        String? userPassword = Console.ReadLine();
        
        User user = new User(userName, userPassword);
        _userDatabase.Users.Add(user);
        _userDatabase.SaveChanges();
        return user;
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public User? Login(User user)
    {
        User? loginUser = _userDatabase.Users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
        if (loginUser == null)
        {
            Console.WriteLine("Wrong username or password");
            return null;
        } 
        return loginUser;
    }
}