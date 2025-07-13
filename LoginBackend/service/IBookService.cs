using LoginBackend.model;

namespace LoginBackend.service;

public interface IBookService
{
    
    Book CreateBook(string author, string title, string note);

    void AddBook(User user, Book book);
    
    void UpdateBook(Book book);
    
    void DeleteBook(Book book);
    
}