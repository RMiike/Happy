using H.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
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
    public class CreateImageModel
    {
        public CreateImageModel(Guid id, string path)
        {
            Id = id;
            Path = path;
        }

        public Guid Id { get; set; }
        public string Path { get; set; }
    }
}
