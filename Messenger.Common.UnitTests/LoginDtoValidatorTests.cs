using FluentValidation;
using FluentValidation.TestHelper;
using Messenger.Common.Dtos;
using Messenger.Common.Validators;

namespace Messenger.Common.UnitTests
{
    public class LoginDtoValidatorTests
    {
        private readonly IValidator<LoginDto> _validator;

        public LoginDtoValidatorTests()
        {
            _validator = new LoginDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Username_Is_Empty()
        {
            var dto = new LoginDto("", "ValidPassword1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        [Fact]
        public void Should_Have_Error_When_Username_Is_Too_Long()
        {
            var dto = new LoginDto(new string('a', 51), "ValidPassword1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        [Fact]
        public void Should_Have_Error_When_Username_Is_Too_Short()
        {
            var dto = new LoginDto("a", "ValidPassword1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        [Fact]
        public void Should_Have_Error_When_Username_Contains_Spaces()
        {
            var dto = new LoginDto("Invalid Username", "ValidPassword1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var dto = new LoginDto("ValidUsername", "");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Too_Long()
        {
            var dto = new LoginDto("ValidUsername", new string('a', 101));
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Too_Short()
        {
            var dto = new LoginDto("ValidUsername", "aA!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Lacks_Uppercase()
        {
            var dto = new LoginDto("ValidUsername", "lowercase1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Lacks_Lowercase()
        {
            var dto = new LoginDto("ValidUsername", "UPPERCASE1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Lacks_Special_Character()
        {
            var dto = new LoginDto("ValidUsername", "ValidPassword1");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Lacks_Digit()
        {
            var dto = new LoginDto("ValidUsername", "ValidPassword!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Contains_Spaces()
        {
            var dto = new LoginDto("ValidUsername", "Invalid Password 1!");
            var result = _validator.TestValidate(dto);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_For_Valid_LoginDto()
        {
            var dto = new LoginDto("ValidUsername", "ValidPassword1!");
            var result = _validator.TestValidate(dto);
            result.ShouldNotHaveAnyValidationErrors();
        }


    }
}

