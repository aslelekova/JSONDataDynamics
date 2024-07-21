namespace ClassLibraryAuthor;

/// <summary>
/// Provides methods to edit author data.
/// </summary>
public class AuthorEditor
{
    /// <summary>
    /// Edits the data of the selected author based on user input.
    /// </summary>
    /// <param name="authors">The list of authors to edit.</param>
    /// <returns>A modified list of authors after editing.</returns>
    public static List<Author> EditAuthorData(List<Author> authors)
    {
        if (!authors.Any())
        {
            Console.WriteLine("Нет доступных авторов.");
            return new List<Author>();
        }

        // Display the list of authors.
        Console.WriteLine("Авторы:");
        for (int i = 0; i < authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {authors[i].Name} {authors[i].AuthorId} Earnings - {authors[i].Earnings}");
        }

        // Prompt user to enter the author number to edit.
        Console.WriteLine("\nВведите номер автора для редактирования:");
        if (!int.TryParse(Console.ReadLine(), out int authorIndex) || authorIndex < 1 || authorIndex > authors.Count)
        {
            Console.WriteLine("Неверный ввод.");
            return new List<Author>();
        }

        var author = authors[authorIndex - 1];

        while (true)
        {
            Console.WriteLine("Выберите поле для редактирования: 1. Имя, 2. Доходы");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Edit author name.
                    Console.WriteLine("Введите новое имя автора:");
                    string newName = Console.ReadLine();
                    author.SetName(newName);
                    Console.WriteLine("Имя автора обновлено.");
                    return authors;
                case "2":
                    // Edit author earnings.
                    Console.WriteLine("Введите новый доход автора:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newEarnings))
                    {
                        author.SetEarnings(newEarnings);
                        Console.WriteLine("Доход автора обновлен.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод.");
                    }
                    return authors;
                default:
                    Console.WriteLine("Неверный выбор поля. Повторите попытку.\n");
                    break;
            }
        }
    }
}