using FluentValidation;
using System;

namespace H.Domain.Entities
{


    public class Image : BaseEntity
    {
        protected Image() { }
        public Image(string path, Guid orphanageId, Orphanage orphanage)
        {
            Path = path;
            OrphanageId = orphanageId;
            Orphanage = orphanage;
        }

        public string Path { get; private set; }
        public Guid OrphanageId { get; private set; }
        public Orphanage Orphanage { get; private set; }
        public override bool IsValid()
        {
            ValidationResult = new ImagesValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class ImagesValidation : AbstractValidator<Image>
        {
            const int MAX_PATH_LENGTH = 250;
            public ImagesValidation()
            {
                RuleFor(x => x.Path)
                     .NotEmpty()
                    .WithMessage("Preencha o caminho da imagem.")
                    .MaximumLength(MAX_PATH_LENGTH)
                    .WithMessage($"Path deve ter no máximo {MAX_PATH_LENGTH} caracteres.");
            }
        }
    }
}
