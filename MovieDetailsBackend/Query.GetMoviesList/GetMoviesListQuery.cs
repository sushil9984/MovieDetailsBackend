namespace MovieDetailsBackend.Query.GetMoviesList
{
    using MediatR;

    public class GetMoviesListQuery : IRequest<MoviesListResponse>
    {
        public static GetMoviesListQuery Create()
        {
            return new GetMoviesListQuery();
        }
    }
}
