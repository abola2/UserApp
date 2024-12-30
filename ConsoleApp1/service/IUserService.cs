using ConsoleApp1.model;

namespace ConsoleApp1.service;

public interface IUserService
{

    bool AlreadyExist(String name);

    User AddUser();
    
    User UpdateUser(User user);
    
    void DeleteUser(User user);
    
    User Login(User user);
    
}