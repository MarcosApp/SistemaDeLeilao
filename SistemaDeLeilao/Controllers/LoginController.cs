using SistemaDeLeilao.Models;
using SistemaDeLeilao.Helper;
using SistemaDeLeilao.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaDeLeilao.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio UsuarioRepositorio,
                               ISessao sessao,
                               IEmail email)
        {
            _UsuarioRepositorio = UsuarioRepositorio;
            _sessao = sessao;
            _email = email; 
        }

        public IActionResult Index()
        {
            // Se Embarcadores estiver loago, redirecionar para a home

            if(_sessao.BuscarSessaoDoEmbarcadores() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoEmbarcadores();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel user = _UsuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoEmbarcadores(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
