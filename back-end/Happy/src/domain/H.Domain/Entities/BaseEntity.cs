using FluentValidation.Results;
using System;
using System.Linq;

namespace H.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }
        public string[] ErrorMessages => ValidationResult?.Errors?.Select(e => e.ErrorMessage)?.ToArray();
        public abstract bool IsValid();
    }
}
