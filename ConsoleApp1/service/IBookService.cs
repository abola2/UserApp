using ConsoleApp1.model;

namespace ConsoleApp1.service;

public interface IBookService
{

    void AddBook(User user, Book book);
    
    void UpdateBook(Book book);
    
    void DeleteBook(Book book);
    
}