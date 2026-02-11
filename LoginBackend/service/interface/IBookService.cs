using LoginBackend.model;

namespace LoginBackend.service;

public interface IBookService
{
    
    Book CreateBook(string author, string title, string note);
    
    List<Book> GetBooks(User user);
    Book GetBook(User user, String id);

    Book AddBook(User user, Book book);
    
    Book UpdateBook(Book book);
    
    void DeleteBook(User user, Book book);
    
}