using TechChallenge.Domain.Entities;

namespace TechChallenge.WebAPI.Models;

public class NewsViewModel
{
    private NewsViewModel(Guid id, string title, string description, DateTime date, string author)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
        Author = author;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public string Author { get; set; }

    public static NewsViewModel MapToViewModel(News news)
    {
        return new NewsViewModel(news.Id, news.Title, news.Description, news.Date, news.Author);
    }

    public static IEnumerable<NewsViewModel> MapToViewModel(IEnumerable<News> news)
    {
        return news.Select(MapToViewModel);
    }
}