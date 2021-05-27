using FluentValidation;
using System.Collections.Generic;

namespace H.Domain.Entities
{
    public class SignUpUser : BaseEntity
    {
        public SignUpUser(string email, string password, string confirmPassword)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public override bool IsValid()
        {
            ValidationResult = new ValidateUser().Validate(this);
            return ValidationResult.IsValid;
        }
        public class ValidateUser : AbstractValidator<SignUpUser>
        {
            private readonly int PASSWORD_MAX_LENGTH = 100;
            private readonly int PASSWORD_MIN_LENGTH = 6;
            public ValidateUser()
            {
                RuleFor(x => x.Email)
                    .NotNull()
                    .WithMessage("O campo Email é obrigatório.")
                    .EmailAddress()
                    .WithMessage("O campo Email está em formato inválido.");

                RuleFor(x => x.Password)
                    .NotNull()
                    .WithMessage("O campo Password é obrigatório.")
                    .Length(PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH)
                    .WithMessage($"O Campo Password deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.");
                ;
                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password)
                    .WithMessage("As senhas não conferem.");
            }
        }
    }
    public class SignInUserResponse
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }
    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
