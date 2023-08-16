namespace TechChallenge.Domain.Entities;

public class News
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }

    public required DateTime Date { get; init; } = DateTime.Now;

    public required string Author { get; init; }

    public static class Factory
    {
        public static News NewPost(string title, string description, DateTime date, string author)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Date = date,
                Author = author
            };
        }
    }
}