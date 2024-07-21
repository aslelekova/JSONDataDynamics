namespace ClassLibraryAuthor;

/// <summary>
/// Handles sorting of author data based on user input.
/// </summary>
public class SortHandler
{
    /// <summary>
    /// Sorts the list of authors based on the selected field.
    /// </summary>
    /// <param name="authors">The list of authors to be sorted.</param>
    /// <returns>The sorted list of authors.</returns>
    public static List<Author> SortData(List<Author> authors)
    {
        while (true)
        {
            Console.WriteLine("Выберите поле для сортировки: 1. Имя, 2. Доходы");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    authors = authors.OrderBy(author => author.Name).ToList();
                    Console.WriteLine("Данные отсортированы по имени.");
                    return authors;
                case "2":
                    authors = authors.OrderBy(author => author.Earnings).ToList();
                    Console.WriteLine("Данные отсортированы по доходам.");
                    return authors;
                default:
                    Console.WriteLine("Неверный ввод поля. Повторите попытку.\n");
                    break;
            }
        }
    }
}