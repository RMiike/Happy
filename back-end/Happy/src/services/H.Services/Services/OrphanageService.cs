using H.BuildingBlocks.Interfaces.Repository;
using H.BuildingBlocks.Interfaces.Service;
using H.Data.Repositories;
using H.Domain.Entities;
using H.Domain.Models;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace H.Services.Services
{
    public class OrphanageService : IOrphanageService
    {

        private readonly IOrphanageRepository _orphanageRepository;

        private readonly IImageService _service;

        private readonly AppSettings _settings;
        public OrphanageService(IOrphanageRepository orphanageRepository,
                                IImageService service,
                                IOptions<AppSettings> settings)
        {
            _orphanageRepository = orphanageRepository;
            _service = service;
            _settings = settings.Value;
        }

        public async Task<CustomizedResult> ObterTodos()
        {
            var orphanages = await _orphanageRepository.ObterTodos();
            if (orphanages == null)
            {
                var result = new CustomizedResult("0 orfanatos registrados", orphanages);
                result.AdicionarMensagensDeErro(unicError: "0 orfanatos registrados");
                return result;
            }

            foreach (var orphanage in orphanages)
            {
                if (!orphanage.IsValid())
                {
                    var result = new CustomizedResult("Found an error", orphanage.ValidationResult);
                    result.AdicionarMensagensDeErro(orphanage.ErrorMessages);
                    return result;
                }
            }
            var models = orphanages.ConvertToModel(_settings.BaseUrl, _settings.RemoteBaseUrl);
            var resultSucess = new CustomizedResult("Todos os orfanatos", models);
            return resultSucess;
        }
        public async Task<CustomizedResult> Adicionar(OrphanageModel model)
        {
            var orphanage = model.ConvertToOrphanage();
            try
            {

                if (!orphanage.IsValid())
                {
                    var invalidResult = new CustomizedResult("Não foi possível adicionar o orphanato", orphanage);
                    invalidResult.AdicionarMensagensDeErro(orphanage.ErrorMessages);
                    return invalidResult;
                }

                var response = await _orphanageRepository.Adicionar(orphanage);
                var fotos = await _service.Adicionar(new ImageModel(response, model.Images));

                var customizedResult = new CustomizedResult("Orphanato adicionado com sucesso.", response.ConvertToModel("~/", "~/"));
                return customizedResult;
            }
            catch (InvalidOperationException e)
            {
                var customizedResult = new CustomizedResult("Não foi possível adicionar o orphanato", $"{e.Message} ");
                customizedResult.AdicionarMensagensDeErro(unicError: e.Message);
                return customizedResult;
            }
            catch (Exception e)
            {
                var customizedResult = new CustomizedResult("Não foi possível adicionar o orphanato", $" {e.Message} ");
                customizedResult.AdicionarMensagensDeErro(unicError: $"exception \r {e.Message} \r {e.Data} \r {e.Source}  \r {e.StackTrace} \r {e.GetBaseException()}");
                return customizedResult;
            }
        }
        public async Task<CustomizedResult> Deletar(Guid id)
        {
            var orphanage = await _orphanageRepository.ObterPorId(id);

            if (orphanage == null)
            {
                var result = new CustomizedResult("Orfanato não existe.", null);
                result.AdicionarMensagensDeErro(unicError: "Orfanato não existe");
                return result;
            }


            return await _orphanageRepository.Deletar(orphanage) ?
                new CustomizedResult($"Orfanato de id {id} deletado com sucesso.", null) :
                new CustomizedResult($"Orfanato de id {id} impossível de deletar.", null);

        }
        public async Task<CustomizedResult> ObterPorId(Guid id)
        {
            var orphanage = await _orphanageRepository.ObterPorId(id);

            if (orphanage == null)
            {
                var result = new CustomizedResult("Orfanato não existe.", null);
                result.AdicionarMensagensDeErro(unicError: "Orfanato não existe");
                return result;
            }

            var orphanageModel = orphanage.ConvertToModel(_settings.BaseUrl, _settings.RemoteBaseUrl);
            var resultOk = new CustomizedResult($"Orfanato de id {id}", orphanageModel);
            return resultOk;
        }
        public async Task<CustomizedResult> ObterPendentes()
        {
            var orphanages = await _orphanageRepository.ObterPendentes();
            if (orphanages == null)
            {
                var result = new CustomizedResult("0 orfanatos registrados", orphanages);
                result.AdicionarMensagensDeErro(unicError: "0 orfanatos registrados");
                return result;
            }

            foreach (var orphanage in orphanages)
            {
                if (!orphanage.IsValid())
                {
                    var result = new CustomizedResult("Found an error", orphanage.ValidationResult);
                    result.AdicionarMensagensDeErro(orphanage.ErrorMessages);
                    return result;
                }
            }
            var models = orphanages.ConvertToModel(_settings.BaseUrl, _settings.RemoteBaseUrl);
            var resultSucess = new CustomizedResult("Todos os orfanatos", models);
            return resultSucess;
        }
        public async Task<CustomizedResult> AprovarCadastro(Guid id)
        {
            try
            {
                var orphanage = await _orphanageRepository.ObterPorId(id);
                if (orphanage == null || orphanage.Pending == false)
                {
                    var invalidResult = new CustomizedResult("Não foi possível aprovar o orphanato", orphanage);
                    invalidResult.AdicionarMensagensDeErro(unicError: "Não foi possível aprovar o orphanato");
                    return invalidResult;
                }
                orphanage.AprovarCadastro();

                var response = await _orphanageRepository.Update(orphanage);

                var customizedResult = new CustomizedResult("Orphanato aprovado com sucesso.", response.ConvertToModel("~/", "~/"));
                return customizedResult;
            }
            catch (Exception e)
            {
                var customizedResult = new CustomizedResult($"Não foi possível aprovar o orphanato {e.Message}", $"{e.Message} ");
                customizedResult.AdicionarMensagensDeErro(unicError: e.Message);
                return customizedResult;
            }
        }
    }
}
