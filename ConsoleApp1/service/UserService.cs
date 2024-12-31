using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class UserService : IUserService
{

    private readonly UserDatabase _userDatabase;
    
    public UserService(UserDatabase userDatabase)
    {
        _userDatabase = userDatabase;
    }


    public bool AlreadyExist(String name)
    {
        return _userDatabase.Users.Any(u => u.Name == name);
    }
    

    public User AddUser(User user)
    {
        if (AlreadyExist(user.Name))
        {
            throw new Exception($"User {user.Name} already exist");
        }
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
            return null;
        } 
        return loginUser;
    }
}