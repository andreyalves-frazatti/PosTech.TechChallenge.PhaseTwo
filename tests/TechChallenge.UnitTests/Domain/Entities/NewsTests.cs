using AutoFixture;
using FluentAssertions;
using TechChallenge.Domain.Entities;

namespace TechChallenge.UnitTests.Domain.Entities;

public class NewsTests
{
    private readonly IFixture _fixture;

    public NewsTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void Should_CreateNews_When_Parameters_IsValid()
    {
        /* arrange */
        var title = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var author = _fixture.Create<string>();

        var date = new DateTime(year: 2023, month: 11, day: 12);
                
        /* act */
        var news = News.Factory.NewPost(title, description, date, author);

        /* assert */
        news.Should().NotBeNull();

        news.Title.Should().Be(title);
        news.Description.Should().Be(description);
        news.Date.Should().Be(date);
        news.Author.Should().Be(author);
    }
}