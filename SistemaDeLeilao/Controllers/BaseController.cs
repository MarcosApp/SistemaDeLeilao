using SistemaDeLeilao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Controllers
{
    public class BaseController : Controller
    {
        private UsuarioModel _usuarioLogado;
        protected UsuarioModel UsuarioLogado => (_usuarioLogado ?? (_usuarioLogado = RequestSessionUsuario()));

        public BaseController()
        {
        }
        public UsuarioModel RequestSessionUsuario()
        {
            string sessaoEmbarcadores = HttpContext.Session.GetString("sessaoUsuarioLogado");
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoEmbarcadores);

            return usuario;
        }
    }
}
