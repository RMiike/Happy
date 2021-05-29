using H.Domain.Entities;
using H.Domain.Models;

namespace H.Domain.MapperEntities
{
    public static class ForgotModelToEntityMapping
    {
        public static ForgotPasswordUser ConvertToEntity(this ForgotPasswordModel model)
            => new ForgotPasswordUser(model.Email);
    }
}
