using H.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace H.Domain.Models
{
    public class OrphanageModel
    {
        public OrphanageModel()
        {
        }
        public OrphanageModel(Guid id, string name, decimal latitude, decimal longitude, string about, string instructions, string openingHours, bool openOnWeekends)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            About = about;
            Instructions = instructions;
            OpeningHours = openingHours;
            OpenOnWeekends = openOnWeekends;
        }

        public OrphanageModel(Guid id, string name, decimal latitude, decimal longitude, string about, string instructions, string openingHours, bool openOnWeekends, IEnumerable<string> imagesPath)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            About = about;
            Instructions = instructions;
            OpeningHours = openingHours;
            OpenOnWeekends = openOnWeekends;
            ImagesPath = imagesPath;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string About { get; set; }
        public string Instructions { get; set; }
        public string OpeningHours { get; set; }
        public bool OpenOnWeekends { get; set; }
        public IEnumerable<string> ImagesPath { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
