using ConsoleApp1.controller;
using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class ConsoleManager
{
    
    private readonly UserController _userController;
    
    public ConsoleManager(UserController userController)
    {
        _userController = userController;
        
    }

    private Dictionary<String, User> _users = new Dictionary<String, User>();

    private static int LOGIN = 0;
    private static int NEW_ACCOUNT = 1;

    public void ReadUserInput()
    {
        UserDatabase.Instance.Database.EnsureCreated();


        int userAction = Login();

        if (userAction == LOGIN)
        {
            
        }
        else if (userAction == NEW_ACCOUNT)
        {
            User user = _userController.AddUser();
            Console.WriteLine(user.Name);
        }

        
        
    }



    private int Login()
    {
        while (true)
        {
            Console.WriteLine("Do you want login or create new account?");
            Console.WriteLine("(0) LOGIN");
            Console.WriteLine("(1) NEW ACCOUNT");
            String ?input = Console.ReadLine();
            bool success = int.TryParse(input, out int userAction);
            if (success)
            {
                if (userAction == LOGIN || userAction == NEW_ACCOUNT)
                {
                    return userAction;
                }
            }
        }
        
    }

    
}