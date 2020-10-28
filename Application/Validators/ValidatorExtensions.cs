using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T,string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[A-Z]").WithMessage("password must contain 1 upper case letter ")
                .Matches("[a-z]").WithMessage(" password must contain alteast one lowercase")
                .Matches("[0-9]").WithMessage("Password must contain atleast one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain one alphanumeric");

           return options;     
        }
    }
}