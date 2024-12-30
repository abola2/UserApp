using ConsoleApp1.model;

namespace ConsoleApp1.service;

public class BookSerivce : IBookService
{
    public void AddBook(User user, Book book)
    {
        Console.WriteLine("Hello book");
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }
}