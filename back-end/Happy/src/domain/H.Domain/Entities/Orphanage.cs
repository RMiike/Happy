using FluentValidation;
namespace H.Domain.Entities
{
    public class Orphanage : BaseEntity
    {
        protected Orphanage() { }
        public Orphanage(
            string name,
            decimal latitude,
            decimal longitude,
            string about,
            string instructions,
            bool openOnWeekends)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            About = about;
            Instructions = instructions;
            OpenOnWeekends = openOnWeekends;
        }

        public string Name { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public string About { get; private set; }
        public string Instructions { get; private set; }
        public string OpeningHours { get; private set; }
        public bool OpenOnWeekends { get; private set; }
        public override bool IsValid()
            => new OrphanageValidation().Validate(this).IsValid;

        public class OrphanageValidation : AbstractValidator<Orphanage>
        {
            public OrphanageValidation()
            {

            }
        }
    }
}
