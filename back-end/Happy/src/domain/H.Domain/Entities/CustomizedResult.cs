using System.Collections.Generic;

namespace H.Domain.Entities
{
    public class CustomizedResult
    {
        public CustomizedResult(string info, object data)
        {
            Ínfo = info;
            Data = data;
        }
        public string Ínfo { get; protected set; }
        public object Data { get; protected set; }
        public Erros Erros { get; protected set; } = new Erros();
        public void AdicionarMensagensDeErro(string[] erros = null, string unicError = null)
        {
            if (erros != null)
            {
                foreach (var erro in erros)
                {
                    Erros.Mensages.Add(erro);
                }
            }
            else
            {
                Erros.Mensages.Add(unicError);
            }
        }
    }
    public class Erros
    {
        public Erros()
        {
            Mensages = new List<string>();
        }
        public List<string> Mensages { get; protected set; }

    }
}
