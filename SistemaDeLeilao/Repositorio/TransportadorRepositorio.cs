using Microsoft.EntityFrameworkCore;
using SistemaDeLeilao.Data;
using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Repositorio
{
    public class TransportadorRepositorio : ITransportadorRepositorio
    {
        private readonly BancoContent _context;

        public TransportadorRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public TransportadorModel Adicionar(TransportadorModel transportadorModel)
        {
            transportadorModel.DataCadastro = DateTime.Now;
            transportadorModel.Usuario.DataCadastro = DateTime.Now;
            transportadorModel.Usuario.SetSenhaHash();
            transportadorModel.Usuario = transportadorModel.Usuario;
            transportadorModel.Embarcadores = transportadorModel.Embarcadores;
            _context.Transportadores.Add(transportadorModel);
            _context.SaveChanges();
            return transportadorModel;
        }

        public bool Apagar(int id)
        {
            TransportadorModel transportadorModel = BuscarPorID(id);

            if (transportadorModel == null) throw new Exception("Houve um erro na deleção do usuário!");

            _context.Usuario.Remove(transportadorModel.Usuario);
            _context.Transportadores.Remove(transportadorModel);
            _context.SaveChanges();
            return true;
        }

        public TransportadorModel Atualizar(TransportadorModel transportadorModel)
        {
            TransportadorModel TransportadorDB = BuscarPorID(transportadorModel.Id);

            if (TransportadorDB == null) throw new Exception("Houve um erro na atualização do transportador!");

            TransportadorDB.DataAtualizacao = DateTime.Now;
            TransportadorDB.Nome = transportadorModel.Nome;
            TransportadorDB.Embarcadores = transportadorModel.Embarcadores;
            TransportadorDB.Usuario.DataAtualizacao = DateTime.Now;
            TransportadorDB.Usuario.SetSenhaHash();
            TransportadorDB.Usuario = transportadorModel.Usuario;
            _context.Transportadores.Update(TransportadorDB);
            _context.SaveChanges();

            return TransportadorDB;
        }

        public TransportadorModel BuscarPorID(int id)
        {
            return _context.Transportadores
                .Include(x => x.Usuario)
                .Include(x => x.Embarcadores)
                .FirstOrDefault(x => x.Id == id);
        }

        public TransportadorModel BuscarPorUsuario(int idUsuario)
        {
            return _context.Transportadores
                .Include(x => x.Usuario)
                .Include(x => x.Embarcadores)
                .FirstOrDefault(x => x.Usuario.Id == idUsuario);
        }

        public List<TransportadorModel> BuscarTodos()
        {
            return _context.Transportadores
                .Include(x => x.Usuario)
                .Include(x => x.Embarcadores).ToList();
        }

        public ICollection<TransportadorModel> BuscarTransportador(int[] selectedTransportadorIds)
        {
            if (selectedTransportadorIds == null) return new List<TransportadorModel>();
            return _context.Transportadores
                .Where(x => selectedTransportadorIds.Contains(x.Id)).ToList();
        }
    }
}
