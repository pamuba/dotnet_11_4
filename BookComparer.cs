using Book;
using System.Collections;

namespace BookComparer;
public class BookComparer : IComparer<Book.Book>
{
    //public int Compare(object? x, object? y)
    //{
    //    Book.Book book1 = x as Book.Book;
    //    Book.Book book2 = y as Book.Book;
    //    int titleComparison = string.Compare(book1.Title, book2.Title, StringComparison.OrdinalIgnoreCase);
    //    if (titleComparison == 0)
    //    {
    //        return string.Compare(book1.Author, book2.Author, StringComparison.OrdinalIgnoreCase);
    //    }
    //    return titleComparison;
    //}

    public int Compare(Book.Book? book1, Book.Book? book2)
    {
        int titleComparison = string.Compare(book1.Title, book2.Title, StringComparison.OrdinalIgnoreCase);
        if (titleComparison == 0)
        {
            return string.Compare(book1.Author, book2.Author, StringComparison.OrdinalIgnoreCase);
        }
        return titleComparison;
    }
}