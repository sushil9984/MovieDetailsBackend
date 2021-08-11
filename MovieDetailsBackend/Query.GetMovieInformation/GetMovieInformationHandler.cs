namespace MovieDetailsBackend.Query.GetMovieInformation
{
    using MediatR;
    using MovieDetailsBackend.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMovieInformationHandler : IRequestHandler<GetMovieInformationQuery, MovieInformationResponse>
    {
        private readonly IRepository repository;

        public GetMovieInformationHandler(IRepository repository)
        {
            this.repository = repository;
        }
        public Task<MovieInformationResponse> Handle(GetMovieInformationQuery request, CancellationToken cancellationToken)
        {
            // Gets Movies Details from DB (i.e. json)
            var movies = this.repository.GetMovieDetailsByTitle(request.Title);

            if (movies?.Result != null)
            {
                return MovieInformationResponse.MapMovieInformationResponse(movies.Result);
            }
            return MovieInformationResponse.CreateNotFoundError();
        }
    }
}
