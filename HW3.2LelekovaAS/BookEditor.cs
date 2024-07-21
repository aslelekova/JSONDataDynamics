namespace ClassLibraryAuthor;

/// <summary>
/// Provides methods for editing book earnings.
/// </summary>
public class BookEditor
{
    /// <summary>
    /// Edits the earnings of books in the specified list of authors.
    /// </summary>
    /// <param name="authors">The list of authors containing books to edit.</param>
    public static void EditBookEarnings(List<Author> authors)
    {
        // Combine all books from authors into one list.
        var allBooks = authors.SelectMany(a => a.Books).ToList();
        if (!allBooks.Any())
        {
            Console.WriteLine("Нет доступных книг.");
            return;
        }

        // Display the list of books.
        Console.WriteLine("Книги:");
        for (int i = 0; i < allBooks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allBooks[i].Title} {allBooks[i].BookId} Earnings - {allBooks[i].Earnings}");
        }

        // Prompt user to enter the book number to edit.
        Console.WriteLine("\nВведите номер книги для изменения дохода:");
        if (!int.TryParse(Console.ReadLine(), out int bookIndex) || bookIndex < 1 || bookIndex > allBooks.Count)
        {
            Console.WriteLine("Неверный ввод.");
            return;
        }

        var book = allBooks[bookIndex - 1];

        // Prompt user to enter the new earnings for the book.
        Console.WriteLine("Введите новый доход книги:");
        if (decimal.TryParse(Console.ReadLine(), out decimal newEarnings))
        {
            book.Earnings = newEarnings;
            Console.WriteLine("Доход книги обновлен.");
        }
        else
        {
            Console.WriteLine("Некорректный ввод.");
        }
    }

}