using H.Domain.Entities;
using H.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace H.Data.Repositories
{
    public static class OrphanageModelAndEntityMapping
    {
        public static Orphanage ConvertToOrphanage(this OrphanageModel orphanageModel, bool pending = true)
        {

            return new Orphanage(orphanageModel.Name,
                                orphanageModel.Latitude,
                                 orphanageModel.Longitude,
                                 orphanageModel.About,
                                 orphanageModel.Instructions,
                                 orphanageModel.OpeningHours,
                                 orphanageModel.OpenOnWeekends,
                                 pending);
        }

        public static IEnumerable<OrphanageModel> ConvertToModel(this IEnumerable<Orphanage> orphanages, string baseUrl, string remoteBaseUrl)
          => new List<OrphanageModel>(orphanages
              .Select(o => new OrphanageModel(o.Id,
                                              o.Name,
                                              o.Latitude,
                                              o.Longitude,
                                              o.About,
                                              o.Instructions,
                                              o.OpeningHours,
                                              o.OpenOnWeekends,
                                              o.Images == null ? null : o.Images.Select(x => new CreateImageModel(x.Id, $"{baseUrl}Images/{x.Path}")),
                                              o.Images == null ? null : o.Images.Select(x => new CreateImageModel(x.Id, $"{remoteBaseUrl}Images/{x.Path}"))
                                              )));


        public static OrphanageModel ConvertToModel(this Orphanage orphanage, string baseUrl, string remoteBaseUrl)
          => new OrphanageModel(orphanage.Id,
                                orphanage.Name,
                                orphanage.Latitude,
                                orphanage.Longitude,
                                orphanage.About,
                                orphanage.Instructions,
                                orphanage.OpeningHours,
                                orphanage.OpenOnWeekends,
                                orphanage.Images == null ? null : orphanage.Images.Select(x => new CreateImageModel(x.Id, $"{baseUrl}Images/{x.Path}")),
                                orphanage.Images == null ? null : orphanage.Images.Select(x => new CreateImageModel(x.Id, $"{remoteBaseUrl}Images/{x.Path}"))
                              );

    }

}
