using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeLeilao.Filters;
using SistemaDeLeilao.Models;
using SistemaDeLeilao.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Controllers
{
    [PaginaParaEmbarcadoresLogado]
    public class TransportadoresController : BaseController
    {
        private readonly IEmbarcadoresRepositorio _EmbarcadoresRepositorio;
        private readonly ITransportadorRepositorio _TransportadorRepositorio;
        public TransportadoresController(IEmbarcadoresRepositorio EmbarcadoresRepositorio
                                        , ITransportadorRepositorio TransportadorRepositorio)
        {
            _EmbarcadoresRepositorio = EmbarcadoresRepositorio;
            _TransportadorRepositorio = TransportadorRepositorio;
        }
        public IActionResult Index()
        {
            List<TransportadorModel> transportadores = _TransportadorRepositorio.BuscarTodos();
            return View(transportadores);
        }

        public IActionResult Criar()
        {
            ViewBag.Lista = GerarSelectListEmbarcadores();
            return View();
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Lista = GerarSelectListEmbarcadores();
            TransportadorModel Funcionario = _TransportadorRepositorio.BuscarPorID(id);
            return View(Funcionario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            TransportadorModel Funcionario = _TransportadorRepositorio.BuscarPorID(id);
            return View(Funcionario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _TransportadorRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Transporte apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu Transporte, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(TransportadorModel transportadorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    transportadorModel.Embarcadores = _EmbarcadoresRepositorio.BuscarTransportador(transportadorModel.SelectedEmbarcadoresIds);
                    transportadorModel = _TransportadorRepositorio.Adicionar(transportadorModel);

                    TempData["MensagemSucesso"] = "Transporte cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                ViewBag.Lista = GerarSelectListEmbarcadores();

                return View(transportadorModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Transporte, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(TransportadorModel transportadorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    transportadorModel.Embarcadores = _EmbarcadoresRepositorio.BuscarTransportador(transportadorModel.SelectedEmbarcadoresIds);
                    transportadorModel = _TransportadorRepositorio.Atualizar(transportadorModel);
                    TempData["MensagemSucesso"] = "Funcionario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                ViewBag.Lista = GerarSelectListEmbarcadores();
                return View(transportadorModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu Funcionario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        private List<SelectListItem> GerarSelectListEmbarcadores()
        {
            return _EmbarcadoresRepositorio.BuscarTodos().ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nome.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
        }

    }
}
