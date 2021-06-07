using FluentValidation;
using System;
using System.Collections.Generic;

namespace H.Domain.Entities
{
    public class Orphanage : BaseEntity
    {
        public Orphanage(string name,
                         decimal latitude,
                         decimal longitude,
                         string about,
                         string instructions,
                         string openingHours,
                         bool openOnWeekends,
                         bool pending)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            About = about;
            Instructions = instructions;
            OpeningHours = openingHours;
            OpenOnWeekends = openOnWeekends;
            Pending = pending;
        }

        public Orphanage(Guid id,
                         string name,
                         decimal latitude,
                         decimal longitude,
                         string about,
                         string instructions,
                         string openingHours,
                         bool openOnWeekends,
                         bool pending,
                         IEnumerable<Image> imagesPath)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            About = about;
            Instructions = instructions;
            OpeningHours = openingHours;
            OpenOnWeekends = openOnWeekends;
            Images = imagesPath;
            Pending = pending;
        }

        protected Orphanage() { }

        public string Name { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public string About { get; private set; }
        public string Instructions { get; private set; }
        public string OpeningHours { get; private set; }
        public bool OpenOnWeekends { get; private set; }
        public bool Pending { get; private set; }
        public IEnumerable<Image> Images { get; set; }
        public void AprovarCadastro()
        {
            if (Pending == true)
                Pending = false;
            return;
        }
        public override bool IsValid()
        {
            ValidationResult = new OrphanageValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public class OrphanageValidation : AbstractValidator<Orphanage>
        {
            const int MAX_NAME_LENGTH = 20;
            const int MAX_ABOUT_LENGTH = 150;
            const int MAX_INSTRUCTION_LENGTH = 150;
            const int MAX_OPENING_HOURS_LENGTH = 20;
            public OrphanageValidation()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Preencha o nome do orfanato.")
                    .MaximumLength(MAX_NAME_LENGTH)
                    .WithMessage($"Nome do orfanato deve ter no máximo {MAX_NAME_LENGTH} caracteres.");

                RuleFor(x => x.About)
                    .NotEmpty()
                    .WithMessage("Preencha o campo 'sobre' do orfanato.")
                    .MaximumLength(MAX_ABOUT_LENGTH)
                    .WithMessage($"Campo sobre deve ter no máximo {MAX_ABOUT_LENGTH} caracteres.");

                RuleFor(x => x.Instructions)
                    .NotEmpty()
                    .WithMessage("Preencha as instruções do orfanato.")
                    .MaximumLength(MAX_INSTRUCTION_LENGTH)
                    .WithMessage($"As instruções devem ter no máximo {MAX_INSTRUCTION_LENGTH} caracteres.");

                RuleFor(x => x.OpeningHours)
                    .NotEmpty()
                    .WithMessage("Preencha o horário de abertura do orfanato.")
                    .MaximumLength(MAX_OPENING_HOURS_LENGTH)
                    .WithMessage($"Campo horário de abertura do orfanato deve ter no máximo {MAX_OPENING_HOURS_LENGTH} caracteres.");

                RuleFor(x => x.Latitude)
                    .NotEmpty()
                    .WithMessage($"Preencha a latitude.");

                RuleFor(x => x.Longitude)
                    .NotEmpty()
                    .WithMessage($"Preencha a Longitude.");

                RuleFor(x => x.OpenOnWeekends)
                    .Must(x => x == false || x == true);
            }
        }
    }
}
