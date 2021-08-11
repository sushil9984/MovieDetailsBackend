namespace MovieDetailsBackend.Tests.Handlers.Tests.Query.Query.GetMoviesList.Tests
{
    using FluentAssertions;
    using Moq;
    using MovieDetailsBackend.Constants;
    using MovieDetailsBackend.Models;
    using MovieDetailsBackend.Query.GetMoviesList;
    using MovieDetailsBackend.Services;
    using System.Collections.Generic;
    using System.Net;
    using Xunit;

    public class GetMoviesListHandlerTests
    {
        private readonly Mock<IRepository> moqRepository = new Mock<IRepository>();
        private MoviesList moviesList = new MoviesList();

        [Fact]
        public void WhenYouTryToFindMovies_ReturnsMoviesCorrectly()
        {
            // Arrange
            SetupOk();
            var requestQuery = new GetMoviesListQuery();
            var sut = new GetMoviesListHandler(moqRepository.Object);

            // Act
            var result = sut.Handle(requestQuery, new System.Threading.CancellationToken());

            // Assert
            result.Result.Status.Should().Be(HttpStatusCode.OK);
            result.Result.Movies.Should().BeEquivalentTo(moviesList.Movies);
        }

        [Fact]
        public void WhenYouTryToFindMovieDetails_ReturnsNotFound()
        {
            // Arrange
            SetupNotFound();
            var requestQuery = new GetMoviesListQuery();
            var sut = new GetMoviesListHandler(moqRepository.Object);

            // Act
            var result = sut.Handle(requestQuery, new System.Threading.CancellationToken());

            // Assert
            result.Result.Status.Should().Be(HttpStatusCode.NotFound);
            result.Result.ErrorMessage.Should().BeEquivalentTo(MovieDetailsConstants.MoviesNotFoundMessage);
        }

        private void SetupOk()
        {
            var movies = new List<MovieInformation>();
            var movieDetails = new MovieInformation
            {
                Language = "ENGLISH",
                Location = "PUNE",
                Title = "Harry Potter and the Chamber of Secrets"
            };
            movies.Add(movieDetails);

            movieDetails = new MovieInformation
            {
                Language = "HINDI",
                Location = "DELHI",
                Title = "Harry Potter and the Deathly Hallows: Part 2"
            };
            movies.Add(movieDetails);

            moviesList.Movies = movies;

            moqRepository.Setup(a => a.GetMoviesDetails()).
                ReturnsAsync(moviesList);
        }

        private void SetupNotFound()
        {
            moviesList = null;
            moqRepository.Setup(a => a.GetMoviesDetails()).
                ReturnsAsync(moviesList);
        }
    }
}
