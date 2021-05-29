using FluentValidation;

namespace H.Domain.Entities
{
    public class ForgotPasswordUser : BaseEntity
    {
        public ForgotPasswordUser(string email)
        {
            Email = email;
        }
        public string Email { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ValidateForgotPasswordUser().Validate(this);
            return ValidationResult.IsValid;
        }
        public class ValidateForgotPasswordUser : AbstractValidator<ForgotPasswordUser>
        {
            private readonly int PASSWORD_MAX_LENGTH = 100;
            private readonly int PASSWORD_MIN_LENGTH = 6;
            public ValidateForgotPasswordUser()
            {
                RuleFor(x => x.Email)
                     .NotNull()
                     .WithMessage("O campo Email é obrigatório.")
                     .EmailAddress()
                     .WithMessage("O campo Email está em formato inválido.");
            }
        }
    }
}
