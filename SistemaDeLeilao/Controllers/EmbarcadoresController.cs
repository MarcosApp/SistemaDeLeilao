using SistemaDeLeilao.Models;
using SistemaDeLeilao.Filters;
using SistemaDeLeilao.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace SistemaDeLeilao.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class EmbarcadoresController : BaseController
    {
        private readonly IEmbarcadoresRepositorio _EmbarcadoresRepositorio;
        private readonly ITransportadorRepositorio _TransportadorRepositorio;

        public EmbarcadoresController(IEmbarcadoresRepositorio EmbarcadoresRepositorio,
                                      ITransportadorRepositorio TransportadorRepositorio)
        {
            _EmbarcadoresRepositorio = EmbarcadoresRepositorio;
            _TransportadorRepositorio = TransportadorRepositorio;
        }

        public IActionResult Index()
        {
            List<EmbarcadoresModel> Embarcadoress = _EmbarcadoresRepositorio.BuscarTodos();

            return View(Embarcadoress);
        }

        public IActionResult Criar()
        {
            ViewBag.Lista = GerarSelectListTransport();
            return View();
        }

        private List<SelectListItem> GerarSelectListTransport()
        {
            return _TransportadorRepositorio.BuscarTodos().ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nome.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Lista = GerarSelectListTransport();
            EmbarcadoresModel Embarcadores = _EmbarcadoresRepositorio.BuscarPorID(id);
            return View(Embarcadores);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            EmbarcadoresModel Embarcadores = _EmbarcadoresRepositorio.BuscarPorID(id);
            return View(Embarcadores);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _EmbarcadoresRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Embarcador apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(EmbarcadoresModel Embarcadores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Embarcadores.Transportador = _TransportadorRepositorio.BuscarTransportador(Embarcadores.SelectedTransportadorIds);
                    Embarcadores = _EmbarcadoresRepositorio.Adicionar(Embarcadores);

                    TempData["MensagemSucesso"] = "Embarcador cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(Embarcadores);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(EmbarcadoresModel Embarcadores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Embarcadores.Transportador = _TransportadorRepositorio.BuscarTransportador(Embarcadores.SelectedTransportadorIds);
                    Embarcadores = _EmbarcadoresRepositorio.Atualizar(Embarcadores);
                    TempData["MensagemSucesso"] = "Embarcador alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(Embarcadores);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
