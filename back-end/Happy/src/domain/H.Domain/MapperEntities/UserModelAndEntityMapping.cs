using H.Domain.Entities;
using H.Domain.Models;

namespace H.Domain.MapperEntities
{
    public static class UserModelAndEntityMapping
    {
        public static SignInUser ConvertToSignIn(this SignInUserModel model)
            => new SignInUser(model.Email, model.Password);
        public static SignUpUser ConvertToSignUp(this SignUpUserModel model)
            => new SignUpUser(model.Email, model.Password, model.ConfirmPassword);
    }
}
