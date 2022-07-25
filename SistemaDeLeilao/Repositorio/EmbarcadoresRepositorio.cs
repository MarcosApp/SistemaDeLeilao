using SistemaDeLeilao.Models;
using SistemaDeLeilao.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeLeilao.Repositorio
{
    public class EmbarcadoresRepositorio : IEmbarcadoresRepositorio
    {
        private readonly BancoContent _context;

        public EmbarcadoresRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public EmbarcadoresModel BuscarPorID(int id)
        {
            return _context.Embarcadores
                .Include(x => x.Usuario)
                .Include(x => x.Transportador)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<EmbarcadoresModel> BuscarTodos()
        {
            return _context.Embarcadores
                .Include(x => x.Usuario)
                .Include(x => x.Transportador)
                .ToList();
        }

        public List<EmbarcadoresModel> BuscarFuncionariosEmbarcador(int id)
        {
            return _context.Embarcadores.Where(x => x.Usuario.Id == id).ToList();
        }

        public EmbarcadoresModel Adicionar(EmbarcadoresModel Embarcadores)
        {
            Embarcadores.DataCadastro = DateTime.Now;
            Embarcadores.Usuario.DataCadastro = DateTime.Now;
            Embarcadores.Usuario.SetSenhaHash();
            Embarcadores.Usuario = Embarcadores.Usuario;
            _context.Embarcadores.Add(Embarcadores);
            _context.SaveChanges();
            return Embarcadores;
        }

        public EmbarcadoresModel Atualizar(EmbarcadoresModel Embarcadores)
        {
            EmbarcadoresModel EmbarcadoresDB = BuscarPorID(Embarcadores.Id);

            if (EmbarcadoresDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            EmbarcadoresDB.DataAtualizacao = DateTime.Now;
            EmbarcadoresDB.Nome = Embarcadores.Nome;
            EmbarcadoresDB.Transportador = Embarcadores.Transportador;
            EmbarcadoresDB.Usuario.DataAtualizacao = DateTime.Now;
            EmbarcadoresDB.Usuario = Embarcadores.Usuario;
            Embarcadores.Usuario.SetSenhaHash();
            Embarcadores.Usuario = Embarcadores.Usuario;
            _context.Embarcadores.Update(EmbarcadoresDB);
            _context.SaveChanges();

            return EmbarcadoresDB;
        }


        public bool Apagar(int id)
        {
            EmbarcadoresModel EmbarcadoresDB = BuscarPorID(id);

            if (EmbarcadoresDB == null) return false;

            _context.Usuario.Remove(EmbarcadoresDB.Usuario);
            _context.Embarcadores.Remove(EmbarcadoresDB);
            _context.SaveChanges();

            return true;
        }

        public ICollection<EmbarcadoresModel> BuscarTransportador(int[] selectedEmbarcadoresIds)
        {
            if (selectedEmbarcadoresIds == null) return new List<EmbarcadoresModel>();
            return _context.Embarcadores
                 .Where(x => selectedEmbarcadoresIds.Contains(x.Id)).ToList();
        }

       
    }
}
