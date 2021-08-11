namespace MovieDetailsBackend.Tests.Handlers.Tests.Query.Query.GetMovieInformation.Tests
{
    using FluentAssertions;
    using Moq;
    using MovieDetailsBackend.Constants;
    using MovieDetailsBackend.Models;
    using MovieDetailsBackend.Query.GetMovieInformation;
    using MovieDetailsBackend.Services;
    using System.Collections.Generic;
    using System.Net;
    using Xunit;

    public class GetMovieInformationHandlerTests
    {
        private readonly Mock<IRepository> moqRepository = new Mock<IRepository>();
        private MovieInformation movieDetails = new MovieInformation();

        [Fact]
        public void WhenYouTryToFindMovieDetails_ReturnsMovieDetailsCorrectly()
        {
            // Arrange
            SetupOk();
            var requestQuery = new GetMovieInformationQuery();
            var sut = new GetMovieInformationHandler(moqRepository.Object);

            // Act
            var result = sut.Handle(requestQuery, new System.Threading.CancellationToken());

            // Assert
            result.Result.Status.Should().Be(HttpStatusCode.OK);
            result.Result.MovieDetails.Should().BeEquivalentTo(movieDetails);
        }

        [Fact]
        public void WhenYouTryToFindMovieDetails_ReturnsNotFound()
        {
            // Arrange
            SetupNotFound();
            var requestQuery = new GetMovieInformationQuery();
            var sut = new GetMovieInformationHandler(moqRepository.Object);

            // Act
            var result = sut.Handle(requestQuery, new System.Threading.CancellationToken());

            // Assert
            result.Result.Status.Should().Be(HttpStatusCode.NotFound);
            result.Result.ErrorMessage.Should().BeEquivalentTo(MovieDetailsConstants.MovieDetailsNotFoundMessage);
        }

        private void SetupOk()
        {
            movieDetails = new MovieInformation
            {
                Language = "ENGLISH",
                Location = "PUNE",
                Plot = "Plot Test Details",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_SX300.jpg",
                SoundEffects = new List<string> { "DOLBY" },
                Stills = new List<string> { "https://i.imgur.com/v0ooIH0.gif" },
                Title = "Harry Potter and the Chamber of Secrets",
                ImdbID = "tt0295297",
                ListingType = "NOW_SHOWING",
                ImdbRating = "7.4"
            };

            moqRepository.Setup(a => a.GetMovieDetailsByTitle(It.IsAny<string>())).
                ReturnsAsync(movieDetails);
        }

        private void SetupNotFound()
        {
            movieDetails = null;
            moqRepository.Setup(a => a.GetMovieDetailsByTitle(It.IsAny<string>())).
                ReturnsAsync(movieDetails);
        }
    }
}
