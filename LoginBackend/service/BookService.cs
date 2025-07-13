using LoginBackend.model;

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


    public List<Book> GetBooks(string author)
    {
        return _userDatabase.Books.Where(book => book.Author == author).ToList();
    }

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