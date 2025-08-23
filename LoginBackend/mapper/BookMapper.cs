using LoginBackend.model;

namespace LoginBackend.mapper;

public static class BookMapper
{

    public static BookDto BookToBookDto(this Book book)
    {
        return new BookDto
        {
            Author = book.Author,
            Id = book.Uuid,
            Title = book.Name
        };
    }

    public static List<BookDto> BooksToDto(this List<Book> books)
    {
        return books.Select(b => BookToBookDto(b)).ToList();
    }
    
}