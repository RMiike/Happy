using H.BuildingBlocks.Helpers;
using H.BuildingBlocks.Interfaces.Repository;
using H.BuildingBlocks.Interfaces.Service;
using H.Domain.Entities;
using H.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace H.Services.Services
{
    public class ImageService : IImageService
    {

        private readonly IImageRepository _repository;

        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> ObterPorId(Guid id)
        {
            var images = await _repository.ObterPorId(id);
            if (images == null)
            {
                return null;
            }
            string filePath = Path.Combine(GeneralHelpers.CreateIfNotExistsImagePathAndReturn(), images.Path);
            return filePath;
        }
        public async Task<IEnumerable<Image>> Adicionar(ImageModel model)
        {
            var listImages = new List<Image>();
            if (model.Images == null)
            {
                return listImages;
            }
            foreach (var image in model.Images)
            {
                var customFileName = CreateCustomFileName(image);
                string path = Path.Combine(GeneralHelpers.CreateIfNotExistsImagePathAndReturn(), customFileName);


                var newImage = new Image(customFileName, model.Orphanage.Id, model.Orphanage);
                if (!newImage.IsValid())
                {
                    throw new InvalidOperationException(newImage.ErrorMessages.FirstOrDefault());
                }
                await AdicionarImagemNaPasta(image, path);
                listImages.Add(newImage);
            }
            await _repository.Adicionar(listImages);
            return listImages;
        }

        private static async Task AdicionarImagemNaPasta(IFormFile image, string path)
        {
            var stream = new FileStream(path, FileMode.Create);
            await image.CopyToAsync(stream);
        }

        private string CreateCustomFileName(IFormFile image)
        {
            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
            var extension = Path.GetExtension(image.FileName);
            fileName = $"{fileName}-{DateTime.Now.ToString("yymmssfff")}{extension}";
            return fileName;
        }

    }
}
