using H.Domain.Entities;
using H.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace H.Data.Repositories
{
    public static class OrphanageModelAndEntityMapping
    {
        public static Orphanage ConvertToOrphanage(this OrphanageModel orphanageModel)
            => new Orphanage(orphanageModel.Name,
                             orphanageModel.Latitude,
                             orphanageModel.Longitude,
                             orphanageModel.About,
                             orphanageModel.Instructions,
                             orphanageModel.OpeningHours,
                             orphanageModel.OpenOnWeekends);

        public static IEnumerable<OrphanageModel> ConvertToModel(this IEnumerable<Orphanage> orphanages)
          => new List<OrphanageModel>(orphanages
              .Select(o => new OrphanageModel(o.Id,
                                              o.Name,
                                              o.Latitude,
                                              o.Longitude,
                                              o.About,
                                              o.Instructions,
                                              o.OpeningHours,
                                              o.OpenOnWeekends,
                                              o.Images.Select(x => x.Path.ToString()).ToList())));


        public static OrphanageModel ConvertToModel(this Orphanage orphanage)
          => new OrphanageModel(orphanage.Id,
                                orphanage.Name,
                                orphanage.Latitude,
                                orphanage.Longitude,
                                orphanage.About,
                                orphanage.Instructions,
                                orphanage.OpeningHours,
                                orphanage.OpenOnWeekends,
                                orphanage.Images.Select(x => x.Path.ToString()).ToList());
    }
}
