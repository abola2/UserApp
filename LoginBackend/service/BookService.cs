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
        Book book = new Book(title, author);
        _userDatabase.Books.Add(book);
        
        return book;
    }

    public List<Book> GetBooks(User user)
    {
        var books = _userDatabase.Users.Include(u => u.Books).FirstOrDefault(u => u.Uuid == user.Uuid).Books.ToList();
        return books;
    }


    public List<Book> GetBooks(string author)
    {
        return _userDatabase.Books.Where(book => book.Author == author).ToList();
    }

    public void AddBook(User user, Book book)
    {
        user.Books.Add(book);
        _userDatabase.Users.Update(user);
        _userDatabase.SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        _userDatabase.Books.Update(book);
    }

    public void DeleteBook(Book book)
    {
        _userDatabase.Books.Remove(book);
        _userDatabase.SaveChanges();
    }
}