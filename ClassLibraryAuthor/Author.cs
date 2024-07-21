using ClassLibraryAuthor;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents an author with associated properties and methods.
/// </summary>
public class Author
{
    /// <summary>
    /// Field representing the unique identifier of the author.
    /// </summary>
    private string _authotId;

    /// <summary>
    /// Field representing the name of the author.
    /// </summary>
    private string _name;

    /// <summary>
    /// Field representing the earnings of the author.
    /// </summary>
    private decimal _earnings;

    /// <summary>
    /// Field representing the list of books associated with the author.
    /// </summary>
    private List<Book> _books;
    
    /// <summary>
    /// Gets the unique identifier of the author.
    /// </summary>
    public string AuthorId { get; private set; }
    
    /// <summary>
    /// Gets or sets the name of the author.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Gets or sets the total earnings of the author.
    /// </summary>
    public decimal Earnings
    {
        get => _earnings;
        private set
        {
            if (_earnings != value)
            {
                _earnings = value;
                OnUpdated();
            }
        }
    }

    /// <summary>
    /// Gets the list of books authored by this author.
    /// </summary>
    public List<Book> Books { get; private set; }

    /// <summary>
    /// Occurs when the author information is updated.
    /// </summary>
    public event EventHandler<AuthorEventArgs> Updated;

    /// <summary>
    /// Initializes a new instance of the <see cref="Author"/> class with the specified parameters.
    /// </summary>
    /// <param name="authorId">The unique identifier of the author.</param>
    /// <param name="name">The name of the author.</param>
    /// <param name="earnings">The total earnings of the author.</param>
    /// <param name="books">The list of books authored by the author.</param>
    [JsonConstructor]
    public Author(string authorId, string name, decimal earnings, List<Book> books)
    {
        AuthorId = authorId;
        Name = name;
        _earnings = earnings;
        Books = books ?? new List<Book>();
    }

    /// <summary>
    /// Sets the name of the author if it is not null, empty, or whitespace, and different from the current name.
    /// </summary>
    /// <param name="newName">The new name of the author.</param>
    public void SetName(string newName)
    {
        if (!string.IsNullOrWhiteSpace(newName) && newName != Name)
        {
            Name = newName;
            OnUpdated();
        }
    }

    /// <summary>
    /// Raises the Updated event, indicating that the author information has been updated.
    /// </summary>
    protected virtual void OnUpdated()
    {
        Updated?.Invoke(this, new AuthorEventArgs(DateTime.Now));
    }

    /// <summary>
    /// Recalculates the total earnings of the author based on the earnings of their books.
    /// </summary>
    public void RecalculateEarnings()
    {
        Earnings = Books.Sum(book => book.Earnings);
    }

    /// <summary>
    /// Serializes the author object to a JSON-formatted string with indentation.
    /// </summary>
    /// <returns>A JSON-formatted string representing the author.</returns>
    public string ToJSON()
    {
        return System.Text.Json.JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

    /// <summary>
    /// Sets the total earnings of the author if it is greater than or equal to zero and different from the current earnings.
    /// </summary>
    /// <param name="newEarnings">The new total earnings of the author.</param>
    public void SetEarnings(decimal newEarnings)
    {
        if (newEarnings >= 0 && newEarnings != Earnings)
        {
            Earnings = newEarnings;
            OnUpdated();
        }
    }
}