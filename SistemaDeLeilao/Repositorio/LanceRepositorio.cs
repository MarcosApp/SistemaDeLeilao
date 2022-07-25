using Microsoft.EntityFrameworkCore;
using SistemaDeLeilao.Controllers;
using SistemaDeLeilao.Data;
using SistemaDeLeilao.Enums;
using SistemaDeLeilao.Interface;
using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Repositorio
{
    public class LanceRepositorio : ILanceRepositorio
    {
        private readonly BancoContent _context;

        public LanceRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public LanceModel Adicionar(LanceModel oferta)
        {
            oferta.Id = 0;
            oferta.Status = LanceEnum.EmAnalise;
            _context.Lance.Add(oferta);
            _context.SaveChanges();

            return BuscarPorID(oferta.Id);
        }

        public bool Apagar(int id)
        {
            LanceModel ofertaDB = BuscarPorID(id);

            if (ofertaDB == null) throw new Exception("Houve um erro na deleção do oferta!");

            _context.Remove(ofertaDB);
            _context.SaveChanges();

            return true;
        }

        public LanceModel Atualizar(LanceModel oferta)
        {
            LanceModel ofertaDB = BuscarPorID(oferta.Id);
            ofertaDB.Preco = oferta.Preco;
            ofertaDB.Quantidade = oferta.Quantidade;
            ofertaDB.Status = oferta.Status;

            if (ofertaDB == null) throw new Exception("Houve um erro na atualização do oferta!");

            _context.Update(ofertaDB);
            _context.SaveChanges();

            return ofertaDB;
        }

        public LanceModel BuscarPorID(int id)
        {
            return _context.Lance
                 .Include(x => x.Transportador)
                 .Include(x => x.Oferta)
                 .FirstOrDefault(x => x.Id == id);
        }

        public LanceModel BuscarPorOferta(int id)
        {
            return _context.Lance
                 .Include(x => x.Transportador)
                 .Include(x => x.Oferta)
                 .FirstOrDefault(x => x.Oferta.Id == id);
        }

        public List<LanceModel> BuscarTodos(int id)
        {
            return _context.Lance
               .Include(x => x.Transportador)
               .Include(x => x.Oferta)
               .ToList();

        }

        public List<LanceModel> BuscarTodos()
        {
            return _context.Lance
               .Include(x => x.Transportador)
               .Include(x => x.Oferta)
               .ToList();

        }
    }
}
