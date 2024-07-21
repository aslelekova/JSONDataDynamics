using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibraryAuthor;

/// <summary>
/// Represents a book with properties such as book ID, title, publication year, genre, and earnings.
/// </summary>
public class Book
{
    /// <summary>
    /// Field representing the unique identifier of the book.
    /// </summary>
    private string _bookId;

    /// <summary>
    /// Field representing the title of the book.
    /// </summary>
    private string _title;

    /// <summary>
    /// Field representing the publication year of the book.
    /// </summary>
    private int _publicationYear;

    /// <summary>
    /// Field representing the genre of the book.
    /// </summary>
    private string _genre;

    /// <summary>
    /// Field representing the earnings of the book.
    /// </summary>
    private decimal _earnings;


    /// <summary>
    /// Gets the unique identifier of the book.
    /// </summary>
    public string BookId { get; private set; }

    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets or sets the publication year of the book.
    /// </summary>
    public int PublicationYear { get; private set; }

    /// <summary>
    /// Gets or sets the genre of the book.
    /// </summary>
    public string Genre { get; private set; }

    /// <summary>
    /// Gets or sets the earnings associated with the book.
    /// </summary>
    public decimal Earnings
    {
        get => _earnings;
        set
        {
            if (_earnings != value)
            {
                _earnings = value;
                EarningsChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Event raised when the earnings of the book are changed.
    /// </summary>
    public event EventHandler EarningsChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="Book"/> class with JSON deserialization support.
    /// </summary>
    /// <param name="bookId">The unique identifier of the book.</param>
    /// <param name="title">The title of the book.</param>
    /// <param name="publicationYear">The publication year of the book.</param>
    /// <param name="genre">The genre of the book.</param>
    /// <param name="earnings">The earnings associated with the book.</param>
    [JsonConstructor]
    public Book(string bookId, string title, int publicationYear, string genre, decimal earnings)
    {
        BookId = bookId;
        Title = title;
        PublicationYear = publicationYear;
        Genre = genre;
        _earnings = earnings;
    }

    /// <summary>
    /// Converts the book data to JSON format with an indented structure.
    /// </summary>
    /// <returns>A JSON-formatted string representing the book data.</returns>
    public string ToJSON()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}