using ConsoleApp1.controller;
using ConsoleApp1.model;

namespace ConsoleApp1.service;

public interface IUserService
{

    void AddUser(User user);
    
    void UpdateUser(User user);
    
    void DeleteUser(User user);
    
}