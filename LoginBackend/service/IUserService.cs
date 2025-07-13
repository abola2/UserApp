using LoginBackend.model;

namespace LoginBackend.service;

public interface IUserService
{

    bool AlreadyExist(String name);

    User AddUser(UserRequest user);
    
    User UpdateUser(User user);
    
    void DeleteUser(User user);
    
    User? Login(UserRequest user);

    User? GetSession(String token);

}