using System;

namespace H.Domain.Models
{
    public class OrphanageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string About { get; set; }
        public string Instructions { get; set; }
        public string OpeningHours { get; set; }
        public bool OpenOnWeekends { get; set; }
    }
}
