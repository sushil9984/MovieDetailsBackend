namespace MovieDetailsBackend.Query.GetMovieInformation
{
    using FluentValidation;

    public class GetMovieInformationQueryValidator : AbstractValidator<GetMovieInformationQuery>
    {
        public GetMovieInformationQueryValidator()
        {
            RuleFor(x => x.Title).
                NotNull().
                WithMessage("Please pass a valid Title");

            RuleFor(x => x.Title).
                NotEmpty().
                WithMessage("Please pass a valid Title");
        }
    }
}
