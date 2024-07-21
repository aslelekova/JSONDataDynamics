namespace ClassLibraryAuthor;

/// <summary>
/// Handles updating event subscriptions for book earnings changes.
/// </summary>
public class UpdateSubscriptionHandler
{ 
    /// <summary>
    /// Updates event subscriptions for book earnings changes for a list of authors.
    /// </summary>
    /// <param name="authors">The list of authors whose books' event subscriptions need to be updated.</param>
    public static void UpdateBookEventSubscriptions(List<Author> authors)
    {
        foreach (var author in authors)
        {
            foreach (var book in author.Books)
            {
                book.EarningsChanged -= (sender, e) => BookEarningsChanged(authors, sender, e);
                book.EarningsChanged += (sender, e) => BookEarningsChanged(authors, sender, e); 
            }
        }
    }

    /// <summary>
    /// Handles the event when book earnings are changed.
    /// </summary>
    /// <param name="authors">The list of authors affected by the book earnings change.</param>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event arguments.</param>
    private static void BookEarningsChanged(List<Author> authors, object? sender, EventArgs e)
    {
        if (sender is Book changedBook)
        {
            foreach (var author in authors)
            {
                var booksToUpdate = author.Books.Where(b => b.BookId == changedBook.BookId).ToList();

                foreach (var bookToUpdate in booksToUpdate)
                {
                    // Update the earnings of each book with the new earnings value.
                    bookToUpdate.Earnings = changedBook.Earnings;
                }

                // If there are books to update, recalculate the total earnings for the author.
                if (booksToUpdate.Any())
                {
                    author.RecalculateEarnings();
                }
            }
        }
    }
}