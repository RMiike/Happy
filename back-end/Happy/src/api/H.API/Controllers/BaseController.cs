using FluentValidation.Results;
using H.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace H.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }
        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }
        protected ActionResult CustomResponse(CustomizedResult resposta)
        {
            ResponsePossuiErros(resposta);

            return CustomResponse(resposta.Data);
        }

        protected bool ResponsePossuiErros(CustomizedResult resposta)
        {
            if (resposta == null || !resposta.Erros.Mensages.Any())
                return false;

            foreach (var mensagem in resposta.Erros.Mensages)
            {
                AdicionarErroProcessamento(mensagem);
            }

            return true;
        }
        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }
        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }
    }
}
