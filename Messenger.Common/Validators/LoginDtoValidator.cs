using FluentValidation;
using Messenger.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Common.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .WithMessage("Username is required.")
                .NotEmpty()
                .WithMessage("Username is required.")
                .Length(5, 50)
                .WithMessage("Username must be between 5 and 50 characters long.")
                .Must(x => x.Contains(" ") == false)
                .WithMessage("Username must not contain spaces.")
                .Must(x => x.Any() == false ||  char.IsDigit(x[0]) == false)
                .WithMessage("Username must not start with a digit.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password is required.")
                .NotEmpty()
                .WithMessage("Password is required.")
                .Length(8, 50)
                .WithMessage("Password must be between 8 and 50 characters long.")
                .Must(x => x.Contains(" ") == false)
                .WithMessage("Password must not contain spaces.")
                .Must(x => x.Any(char.IsUpper))
                .WithMessage("Password must contain at least one uppercase letter.")
                .Must(x => x.Any(char.IsLower))
                .WithMessage("Password must contain at least one lowercase letter.")
                .Must(x => x.Any(char.IsDigit))
                .WithMessage("Password must contain at least one digit.")
                .Must(x => x.Any(ch => "!@#$%^&*()_+[]{}|;:,.<>?".Contains(ch)))
                .WithMessage("Password must contain at least one special character.");
        }
    }
}
