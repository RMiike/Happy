using H.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace H.Domain.Models
{
    public class ImageModel
    {
        public ImageModel(Orphanage orphanage, IEnumerable<IFormFile> images)
        {
            Orphanage = orphanage;
            Images = images;
        }

        public Orphanage Orphanage { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
