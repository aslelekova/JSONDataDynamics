using System.Text.Json;

namespace ClassLibraryAuthor;

/// <summary>
/// Provides methods for loading and saving data to/from a file.
/// </summary>
public class FileHandler
{
    /// <summary>
    /// Loads data from a file and updates the provided list of authors and AutoSaver.
    /// </summary>
    /// <param name="filePath">The path to the file containing the data.</param>
    /// <param name="autoSaver">The AutoSaver to be updated with the loaded authors.</param>
    /// <returns>The list of authors loaded from the file.</returns>
    public static List<Author> LoadData(string filePath, AutoSaver autoSaver)
    {
        Console.WriteLine("Введите путь к файлу:");
        string inputPath = Console.ReadLine();

        try
        {
            string json = File.ReadAllText(inputPath);
            List<Author> loadedAuthors = JsonSerializer.Deserialize<List<Author>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            // Update the list of authors in AutoSaver.
            autoSaver.UpdateAuthors(loadedAuthors);

            // Subscribe AutoSaver to Updated events.
            foreach (var author in loadedAuthors)
            {
                author.Updated += autoSaver.OnUpdated;
            }

            UpdateSubscriptionHandler.UpdateBookEventSubscriptions(loadedAuthors);
            Console.WriteLine("Данные успешно загружены.");

            return loadedAuthors;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            return new List<Author>(); 
        }
    }

    /// <summary>
    /// Saves the provided list of authors to a file.
    /// </summary>
    /// <param name="authors">The list of authors to be saved.</param>
    public static void SaveDataToFile(List<Author> authors)
    {
        Console.WriteLine("Введите путь к файлу для сохранения:");
        string saveFilePath = Console.ReadLine();

        try
        {
            string json = JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(saveFilePath, json);
            Console.WriteLine($"Данные успешно сохранены в файл {saveFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
        }
    }
}