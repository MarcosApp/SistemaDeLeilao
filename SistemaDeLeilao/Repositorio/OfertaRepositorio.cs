using Microsoft.EntityFrameworkCore;
using SistemaDeLeilao.Data;
using SistemaDeLeilao.Interface;
using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Repositorio
{
    public class OfertaRepositorio : IOfertaRepositorio
    {
        private readonly BancoContent _context;

        public OfertaRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public OfertaModel Adicionar(OfertaModel oferta)
        {
            _context.Oferta.Add(oferta);
            _context.SaveChanges();

            return BuscarPorID(oferta.Id);
        }

        public bool Apagar(int id)
        {
            OfertaModel ofertaDB = BuscarPorID(id);

            if (ofertaDB == null) throw new Exception("Houve um erro na deleção do oferta!");

            _context.Remove(ofertaDB);
            _context.SaveChanges();

            return true;
        }

        public OfertaModel Atualizar(OfertaModel oferta)
        {
            OfertaModel ofertaDB = BuscarPorID(oferta.Id);
            ofertaDB.NomeOferta = oferta.NomeOferta;
            ofertaDB.Quantidade = oferta.Quantidade;
            ofertaDB.EnderecoColeta = oferta.EnderecoColeta;
            ofertaDB.EnderecoEntrega = oferta.EnderecoEntrega;

            if (ofertaDB == null) throw new Exception("Houve um erro na atualização do oferta!");

            _context.Update(ofertaDB);
            _context.SaveChanges();

            return ofertaDB;
        }

        

        public OfertaModel BuscarPorID(int id)
        {
            return _context.Oferta
                 .Include(x => x.Embarcadores)
                 .Include(x => x.Funcionario)
                 .FirstOrDefault(x => x.Id == id);
        }

        public List<OfertaViewModel> BuscarTodos()
        {

            var result = from ofert in _context.Oferta
                         join detail in _context.Lance on ofert.Id equals detail.Oferta.Id into Details
                         from m in Details.DefaultIfEmpty()
                         select new OfertaViewModel
                         {
                             Id = ofert.Id,
                             NomeOferta = ofert.NomeOferta,
                             EnderecoColeta = ofert.EnderecoColeta,
                             EnderecoEntrega = ofert.EnderecoEntrega,
                             Quantidade = ofert.Quantidade,
                             Lance = new LanceModel()
                             {
                                 Status = m.Status,
                                 Preco = m.Preco
                             }

                         };

            return result.ToList();

        }


    }
}
