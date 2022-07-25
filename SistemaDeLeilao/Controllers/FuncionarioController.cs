using SistemaDeLeilao.Filters;
using SistemaDeLeilao.Models;
using SistemaDeLeilao.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SistemaDeLeilao.Controllers
{
    [PaginaParaEmbarcadoresLogado]
    [PaginaRestritaSomenteEmbarcadores]
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioRepositorio _FuncionarioRepositorio;
        private readonly IEmbarcadoresRepositorio _EmbarcadoresRepositorio;
        public FuncionarioController(IFuncionarioRepositorio FuncionarioRepositorio
                                    , IEmbarcadoresRepositorio EmbarcadoresRepositorio)
        {
            _FuncionarioRepositorio = FuncionarioRepositorio;
            _EmbarcadoresRepositorio = EmbarcadoresRepositorio;
        }

        public IActionResult Index()
        {
            List<FuncionarioModel> Funcionarios =
                RequestSessionUsuario().Perfil == Enums.PerfilEnum.Admin
                ? _FuncionarioRepositorio.BuscarTodos()
                : _FuncionarioRepositorio.BuscarFuncionariosEmbarcador(RequestSessionUsuario().Id);

            return View(Funcionarios);
        }

        public IActionResult Criar()
        {
            TempData["EmbarcadoresList"] = ListaEmbarcadores();
            return View();
        }

        public IActionResult Editar(int id)
        {
            TempData["EmbarcadoresList"] = ListaEmbarcadores();
            FuncionarioModel Funcionario = _FuncionarioRepositorio.BuscarPorID(id);
            return View(Funcionario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            FuncionarioModel Funcionario = _FuncionarioRepositorio.BuscarPorID(id);
            return View(Funcionario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _FuncionarioRepositorio.Apagar(id);

                if(apagado) TempData["MensagemSucesso"] = "Funcionario apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu Funcionario, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(FuncionarioModel Funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Funcionario.Embarcadores == null) throw new Exception("É necessario esta vínculado a um Embarcador");

                    Funcionario.Embarcadores = _EmbarcadoresRepositorio.BuscarPorID(Funcionario.Embarcadores.Id);
                    Funcionario = _FuncionarioRepositorio.Adicionar(Funcionario);

                    TempData["MensagemSucesso"] = "Funcionario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(Funcionario);
            }
            catch (Exception erro)
            { 
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(FuncionarioModel Funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Funcionario.Embarcadores = _EmbarcadoresRepositorio.BuscarPorID(Funcionario.Embarcadores.Id);
                    Funcionario = _FuncionarioRepositorio.Atualizar(Funcionario);
                    TempData["MensagemSucesso"] = "Funcionario alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(Funcionario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public List<EmbarcadoresModel> ListaEmbarcadores()
        {
            return RequestSessionUsuario().Perfil == Enums.PerfilEnum.Admin
                ? _EmbarcadoresRepositorio.BuscarTodos()
                : _EmbarcadoresRepositorio.BuscarFuncionariosEmbarcador(RequestSessionUsuario().Id);
        }

    }
}
