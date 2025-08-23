using LoginBackend.model;

namespace LoginBackend.service;

public interface IBookService
{
    
    Book CreateBook(string author, string title, string note);
    
    List<Book> GetBooks(User user);

    void AddBook(User user, Book book);
    
    void UpdateBook(Book book);
    
    void DeleteBook(Book book);
    
}