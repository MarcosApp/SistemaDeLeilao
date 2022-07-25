using Microsoft.AspNetCore.Mvc;
using SistemaDeLeilao.Filters;
using SistemaDeLeilao.Interface;
using SistemaDeLeilao.Models;
using SistemaDeLeilao.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Controllers
{
    [PaginaRestritaSomenteFuncionarios]
    public class OfertaController : BaseController
    {
        private readonly IOfertaRepositorio _OfertaRepositorio;
        private readonly IFuncionarioRepositorio _FuncionarioRepositorio;
        private readonly IEmbarcadoresRepositorio _EmbarcadoresRepositorio;
        public OfertaController(IOfertaRepositorio OfertaRepositorio
                               , IEmbarcadoresRepositorio EmbarcadoresRepositorio
                               , IFuncionarioRepositorio FuncionarioRepositorio)
        {
            _OfertaRepositorio = OfertaRepositorio;
            _EmbarcadoresRepositorio = EmbarcadoresRepositorio;
            _FuncionarioRepositorio = FuncionarioRepositorio;
        }
        public IActionResult Index()
        {           
            ViewBag.Perfil = RequestSessionUsuario().Perfil;
            List<OfertaViewModel> oferta = _OfertaRepositorio.BuscarTodos();
            return View(oferta);
        }

        public IActionResult Criar()
        {
            ViewBag.Perfil = RequestSessionUsuario().Perfil;
            return View();
        }

        [PaginaRestritaSomenteFuncionarios]
        public IActionResult Editar(int id)
        {
            OfertaModel oferta = _OfertaRepositorio.BuscarPorID(id);
            return View(oferta);
        }

        [PaginaRestritaSomenteFuncionarios]
        public IActionResult ApagarConfirmacao(int id)
        {
            OfertaModel oferta = _OfertaRepositorio.BuscarPorID(id);
            return View(oferta);
        }

        [PaginaRestritaSomenteFuncionarios]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _OfertaRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Oferta apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu Oferta, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [PaginaRestritaSomenteFuncionarios]
        public IActionResult Criar(OfertaModel oferta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FuncionarioModel funcionario = _FuncionarioRepositorio.BuscarPorIDUsuario(RequestSessionUsuario().Id);
                    if (funcionario == null) throw new Exception("É necessario esta vínculado a um Embarcador com perfil de Funcionário");

                    EmbarcadoresModel embarcador = _EmbarcadoresRepositorio.BuscarPorID(funcionario.Embarcadores.Id);
                    if (embarcador == null) throw new Exception("É necessario esta vínculado a um Embarcador com perfil de Funcionário");


                    oferta.Funcionario = funcionario;
                    oferta.Embarcadores = embarcador;
                    oferta = _OfertaRepositorio.Adicionar(oferta);

                    TempData["MensagemSucesso"] = "Oferta cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(oferta);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Oferta, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [PaginaRestritaSomenteFuncionarios]
        public IActionResult Editar(OfertaModel oferta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FuncionarioModel funcionario = _FuncionarioRepositorio.BuscarPorIDUsuario(RequestSessionUsuario().Id);
                    if (funcionario == null) throw new Exception("É necessario esta vínculado a um Embarcador com perfil de Funcionário");

                    EmbarcadoresModel embarcador = _EmbarcadoresRepositorio.BuscarPorID(funcionario.Embarcadores.Id);
                    if (embarcador == null) throw new Exception("É necessario esta vínculado a um Embarcador com perfil de Funcionário");

                    oferta.Funcionario = funcionario;
                    oferta.Embarcadores = embarcador;
                    oferta = _OfertaRepositorio.Atualizar(oferta);
                    TempData["MensagemSucesso"] = "Oferta alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(oferta);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        
    }
}
