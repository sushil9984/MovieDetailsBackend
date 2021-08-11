namespace MovieDetailsBackend.Query.GetMovieInformation
{
    using MediatR;

    public class GetMovieInformationQuery : IRequest<MovieInformationResponse>
    {
        public string Title { get; private set; }

        public static GetMovieInformationQuery Create(string title)
        {
            return new GetMovieInformationQuery
            {
                Title = title
            };
        }
    }
}
