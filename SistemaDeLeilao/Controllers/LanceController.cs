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
    [PaginaParaEmbarcadoresLogado]
    public class LanceController : BaseController
    {
        private readonly IOfertaRepositorio _OfertaRepositorio;
        private readonly ILanceRepositorio _LanceRepositorio;
        private readonly ITransportadorRepositorio _TransportadorRepositorio;
        public LanceController(IOfertaRepositorio OfertaRepositorio
            , ILanceRepositorio LanceRepositorio
            , ITransportadorRepositorio TransportadorRepositorio)
        {
            _OfertaRepositorio = OfertaRepositorio;
            _TransportadorRepositorio = TransportadorRepositorio;
            _LanceRepositorio = LanceRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaLance()
        {
            List<LanceModel> oferta = _LanceRepositorio.BuscarTodos(RequestSessionUsuario().Id);
            return View(oferta);
        }

        public IActionResult RealizarLance(int id)
        {
            OfertaModel oferta = _OfertaRepositorio.BuscarPorID(id);
            return View(new LanceModel() { Oferta = oferta });
        }

        public IActionResult Aprovar(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lance = _LanceRepositorio.BuscarPorID(id);
                    lance.Status = Enums.LanceEnum.Leiloado;
                    _LanceRepositorio.Atualizar(lance);
                    if (lance == null) throw new Exception($"Lance não encontrado. ");
                    TempData["MensagemSucesso"] = "Leiloado com sucesso!";
                    return Redirect($"/Lance/ListaLance");
                }
                return View("ListaLance");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Oferta, tente novamante, detalhe do erro: {erro.Message}";
                return View("ListaLance");
            }

        }

        public IActionResult Recusar(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var lance = _LanceRepositorio.BuscarPorID(id);
                    lance.Status = Enums.LanceEnum.Recusado;
                    _LanceRepositorio.Atualizar(lance);
                    if (lance == null) throw new Exception($"Lance não encontrado. ");
                    TempData["MensagemSucesso"] = "Recusado com sucesso!";
                    return Redirect($"/Lance/ListaLance");
                }
                return View("ListaLance");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Oferta, tente novamante, detalhe do erro: {erro.Message}";
                return View("ListaLance");
            }
        }


        [HttpPost]
        public IActionResult Criar(LanceModel oferta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    oferta.Oferta = _OfertaRepositorio.BuscarPorID(oferta.Id);
                    if (oferta.Quantidade > oferta.Oferta.Quantidade) throw new Exception($"É necessario que a quantidade seja menor que {oferta.Oferta.Quantidade}");
                    oferta.Transportador = _TransportadorRepositorio.BuscarPorUsuario(RequestSessionUsuario().Id);
                    oferta = _LanceRepositorio.Adicionar(oferta);

                    TempData["MensagemSucesso"] = "Lance enviado com sucesso!";
                    return Redirect($"/Oferta/Index");
                }

                return View(oferta);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu Oferta, tente novamante, detalhe do erro: {erro.Message}";
                return Redirect($"/Lance/RealizarLance/{oferta.Id}");
            }
        }
    }
}
