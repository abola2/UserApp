using LoginBackend.model;
using Microsoft.EntityFrameworkCore;

namespace LoginBackend.service;

public class BookService : IBookService
{
    
    private readonly UserDatabase _userDatabase;

    public BookService(UserDatabase userDatabase)
    {
        _userDatabase = userDatabase;
    }
    
    public Book CreateBook(string author, string title, string note)
    {
        var book = new Book(title, author);
        _userDatabase.Books.Add(book);
        
        return book;
    }

    public List<Book> GetBooks(User user)
    {
        var books = _userDatabase.Users.Include(u => u.Books).FirstOrDefault(u => u.Uuid == user.Uuid).Books.ToList();
        return books;
    }


    public Book GetBook(User user, String id)
    {
        return _userDatabase.Users.Include(u => u.Books).FirstOrDefault(u => u.Uuid == user.Uuid).Books.Where(book  => book.Uuid == id).FirstOrDefault();
    }

    public Book AddBook(User user, Book book)
    {
        user.Books.Add(book);
        _userDatabase.Users.Update(user);
        _userDatabase.SaveChanges();
        return book;
    }

    public Book UpdateBook(Book book)
    {
        _userDatabase.Books.Update(book);
        return book;
    }

    public void DeleteBook(User user, Book book)
    {
        _userDatabase.Books.Remove(book);
        _userDatabase.SaveChanges();
    }
}