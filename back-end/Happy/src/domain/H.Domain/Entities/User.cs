using FluentValidation;

namespace H.Domain.Entities
{
    public class User : BaseEntity
    {
        public override bool IsValid()
            => new ValidateUser().Validate(this).IsValid;
        public class ValidateUser : AbstractValidator<User>
        {
            public ValidateUser()
            {

            }
        }
    }
}
