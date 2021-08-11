using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDetailsBackend.Query.GetMovieInformation
{
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
