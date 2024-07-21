using System.Text.Json;

namespace ClassLibraryAuthor;

/// <summary>
/// Automatically saves author data to a file with a specified interval.
/// </summary>
public class AutoSaver
{
    /// <summary>
    /// Field representing a list of authors.
    /// </summary>
    private List<Author> _authors;

    /// <summary>
    /// Field representing the file path.
    /// </summary>
    private readonly string _filePath;

    /// <summary>
    /// Field representing the date and time of the last update.
    /// </summary>
    private DateTime _lastUpdateTime;

    /// <summary>
    /// Field representing the count of updates.
    /// </summary>
    private int _updateCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="AutoSaver"/> class.
    /// </summary>
    /// <param name="filePath">The path to the file where data will be saved.</param>
    /// <param name="authors">The list of authors to be saved.</param>
    public AutoSaver(string filePath, List<Author> authors)
    {
        _filePath = filePath;
        _authors = authors;
        _lastUpdateTime = DateTime.MinValue;
        _updateCount = 0;
    }

    /// <summary>
    /// Updates the list of authors to be saved.
    /// </summary>
    /// <param name="authors">The updated list of authors.</param>
    public void UpdateAuthors(List<Author> authors)
    {
        _authors = authors;
    }

    /// <summary>
    /// Handles the Updated event of the authors and triggers automatic saving.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    public void OnUpdated(object sender, EventArgs e)
    {
        var now = DateTime.Now;

        if ((now - _lastUpdateTime).TotalSeconds > 15)
        {
            _lastUpdateTime = now;
            _updateCount = 1;
        }
        else
        {
            _updateCount++;

            if (_updateCount >= 2)
            {
                SaveToFile();
                _updateCount = 0;
            }
        }
    }

    /// <summary>
    /// Saves the author data to a temporary file with a JSON format.
    /// </summary>
    private void SaveToFile()
    {
        // Create a temporary file path by appending "_tmp.json" to the original file name.
        string tempFilePath = $"{Path.GetFileNameWithoutExtension(_filePath)}_tmp.json";
    
        string json = JsonSerializer.Serialize(_authors, new JsonSerializerOptions { WriteIndented = true });
    
        // Write the JSON data to the temporary file.
        File.WriteAllText(tempFilePath, json);
            
        Console.WriteLine($"Автоматическое сохранение выполнено в {tempFilePath}");
    }
}