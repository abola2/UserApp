using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class UserSerivce : IUserService
{


    public bool AlreadyExist(String name)
    {
        return UserDatabase.Instance.Users.Any(u => u.Name == name);
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
        
        
        return new User(userName, userPassword);
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
        User? loginUser = UserDatabase.Instance.Users.Where(u => u.Name == user.Name && u.Password == user.Password).First();
        if (loginUser != null)
    }
}