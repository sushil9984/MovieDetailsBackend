namespace MovieDetailsBackend.Query.GetMoviesList
{
    using MediatR;
    using MovieDetailsBackend.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMoviesListHandler : IRequestHandler<GetMoviesListQuery, MoviesListResponse>
    {
        private readonly IRepository repository;

        public GetMoviesListHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Task<MoviesListResponse> Handle(GetMoviesListQuery request, CancellationToken cancellationToken)
        {
            // Gets Movies List from DB (i.e. json)
            var movies = this.repository.GetMoviesDetails();

            if (movies?.Result != null)
            {
                return MoviesListResponse.MapResponse(movies.Result);
            }
            return MoviesListResponse.CreateNotFoundError();
        }
    }
}
