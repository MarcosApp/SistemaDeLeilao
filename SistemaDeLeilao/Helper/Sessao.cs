using SistemaDeLeilao.Models;
using SistemaDeLeilao.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SistemaDeLeilao.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoEmbarcadores()
        {
            string sessaoEmbarcadores = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoEmbarcadores)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoEmbarcadores);
        }

        public void CriarSessaoDoEmbarcadores(UsuarioModel Embarcadores)
        {
            string valor = JsonConvert.SerializeObject(Embarcadores);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoEmbarcadores()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
