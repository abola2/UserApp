using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class UserSerivce : IUserService
{
    public void AddUser(User user)
    {
        Console.WriteLine("Hello World!");
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}