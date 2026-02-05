using MartiX.Result.Sample.Core.Model;
using FluentValidation;

namespace MartiX.Result.Sample.Core.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(10)
                .NotEqual("SomeLongName");
            RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
        }
    }
}
