using FluentValidation;

namespace H.Domain.Entities
{
    public class ChangePasswordEntity : BaseEntity
    {
        public ChangePasswordEntity(string oldPassword, string newPassword, string confirmPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        public string OldPassword { get; private set; }
        public string NewPassword { get; private set; }
        public string ConfirmPassword { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ValidateChangePassword().Validate(this);
            return ValidationResult.IsValid;
        }
        public class ValidateChangePassword : AbstractValidator<ChangePasswordEntity>
        {
            private readonly int PASSWORD_MAX_LENGTH = 100;
            private readonly int PASSWORD_MIN_LENGTH = 6;
            public ValidateChangePassword()
            {

                RuleFor(x => x.OldPassword)
                    .NotNull()
                    .WithMessage("O campo Password Antigo é obrigatório.")
                    .Length(PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH)
                    .WithMessage($"O Campo Password Antigo deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.")
                     .Length(PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH)
                    .WithMessage($"O Campo Password Antigo deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.");


                RuleFor(x => x.NewPassword)
                    .NotNull()
                    .WithMessage("O campo Password Novo é obrigatório.")
                    .Length(PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH)
                    .WithMessage($"O Campo Password Novo  deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.")
                     .Length(PASSWORD_MIN_LENGTH, PASSWORD_MAX_LENGTH)
                    .WithMessage($"O Campo Password Novo  deve ter entre {PASSWORD_MIN_LENGTH} e {PASSWORD_MAX_LENGTH} caracteres.");


                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.NewPassword)
                    .WithMessage("As senhas não conferem.");
            }
        }
    }
}
