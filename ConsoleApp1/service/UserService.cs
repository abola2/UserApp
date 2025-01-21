using ConsoleApp1.model;
using ConsoleApp1.Utils;
using Microsoft.EntityFrameworkCore;

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
        User? loginUser = _userDatabase.Users.Include(u => u.SessionToken)
            .FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
        if (loginUser == null)
        {
            return null;
        }

        if (loginUser.SessionToken == null)
        {
            var session = new SessionToken();
            session.User = loginUser;
            session.Uuid = loginUser.Uuid;
            session.Token = SessionUtil.GenerateToken(loginUser.Uuid);
            session.ExpirationDate = DateTime.Now;


            loginUser.SessionToken = session;
            _userDatabase.Users.Update(loginUser);
            _userDatabase.SaveChanges();
        }

        return loginUser;
    }


    public User? GetSession(String token)
    {
        if (String.IsNullOrEmpty(token))
        {
            return null;
        }

        List<User> users = _userDatabase.Users.Include(u => u.SessionToken).ToList();
        User? user = _userDatabase.Users.Include(u => u.SessionToken).FirstOrDefault(user => user.SessionToken.Token == token);

        if (user == null)
        {
            return null;
        }
        
        //if (user.SessionToken.ExpirationDate < DateTime.Now)
        {
        //    return null;
        }

        return user;

    }
}