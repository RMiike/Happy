using H.Domain.Entities;
using H.Domain.Models;

namespace H.Domain.MapperEntities
{
    public static class ChangePassModelToEntityMapping
    {
        public static ChangePasswordEntity ConvertToEntity(this ChangePasswordModel model)
            => new ChangePasswordEntity(model.OldPassword, model.NewPassword, model.ConfirmPassword);
    }
}
