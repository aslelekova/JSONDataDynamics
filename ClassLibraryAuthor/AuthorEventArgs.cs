using System;

namespace ClassLibraryAuthor;

/// <summary>
/// Provides data for the Updated event in the Author class.
/// </summary>
public class AuthorEventArgs : EventArgs
{
    /// <summary>
    /// Field representing the date and time of the last update.
    /// </summary>
    private DateTime _updateTime;

    /// <summary>
    /// Gets the timestamp of the update.
    /// </summary>
    public DateTime UpdateTime { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorEventArgs"/> class with the specified update time.
    /// </summary>
    /// <param name="updateTime">The timestamp of the update.</param>
    public AuthorEventArgs(DateTime updateTime)
    {
        UpdateTime = updateTime;
    }
}