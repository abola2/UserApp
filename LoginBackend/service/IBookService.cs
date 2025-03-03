using ConsoleApp1.model;

namespace ConsoleApp1.service;

public interface IBookService
{
    
    Book CreateBook(string author, string title, string note);

    void AddBook(User user, Book book);
    
    void UpdateBook(Book book);
    
    void DeleteBook(Book book);
    
}