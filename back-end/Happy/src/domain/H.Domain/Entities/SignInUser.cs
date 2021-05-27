using FluentValidation;

namespace H.Domain.Entities
{
    public class SignInUser : BaseEntity
    {
        public SignInUser(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public override bool IsValid()
        {
            ValidationResult = new ValidateLoginUser().Validate(this);
            return ValidationResult.IsValid;
        }
        public class ValidateLoginUser : AbstractValidator<SignInUser>
        {
            private readonly int PASSWORD_MAX_LENGTH = 100;
            private readonly int PASSWORD_MIN_LENGTH = 6;
            public ValidateLoginUser()
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
                    .WithMessage($"O Campo Password deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.")
                     .Length(PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH)
                    .WithMessage($"O Campo Password deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.");
            }
        }
    }
}
