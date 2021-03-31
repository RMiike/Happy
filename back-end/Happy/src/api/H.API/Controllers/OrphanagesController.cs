using H.BuildingBlocks.Interfaces.Service;
using H.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace H.API.Controllers
{
    public class OrphanagesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] IOrphanageService _service)
            => CustomResponse(await _service.ObterTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            Guid id,
            [FromServices] IOrphanageService _service)
            => CustomResponse(await _service.ObterPorId(id));

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] IOrphanageService _service,
            [FromForm] OrphanageModel orphanageModel)
            => CustomResponse(await _service.Adicionar(orphanageModel));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            Guid id,
            [FromServices] IOrphanageService _service)
            => CustomResponse(await _service.Deletar(id));
    }
}
