using LoginBackend.model;
using LoginBackend.Utils;
using Microsoft.EntityFrameworkCore;

namespace LoginBackend.service;

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


    public User AddUser(UserRequest user)
    {
        if (AlreadyExist(user.Name))
        {
            throw new Exception($"User {user.Name} already exist");
        }

        var salt = PasswordUtil.GenerateSalt(16);
        var password = PasswordUtil.HashPassword(user.Password, salt);
        var newUser = new User(user.Name, password, salt);

        _userDatabase.Users.Add(newUser);
        _userDatabase.SaveChanges();
        return newUser;
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public User? Login(UserRequest user)
    {
        
        User lUser= _userDatabase.Users.Include(u => u.SessionToken).FirstOrDefault(u => u.Name == user.Name);
        
        bool validLogin =  PasswordUtil.VerifyPassword(user.Password, lUser.Hash, lUser.Password);
        
        if (!validLogin)
        {
            return null;
        }

        if (lUser.SessionToken == null)
        {
            var session = new SessionToken
            {
                User = lUser,
                Uuid = lUser.Uuid,
                Token = SessionUtil.GenerateToken(lUser.Uuid),
                ExpirationDate = DateTime.Now
            };


            lUser.SessionToken = session;
            _userDatabase.Users.Update(lUser);
            _userDatabase.SaveChanges();
        }

        return lUser;
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