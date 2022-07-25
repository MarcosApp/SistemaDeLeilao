using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Repositorio
{
    public interface ITransportadorRepositorio
    {
        List<TransportadorModel> BuscarTodos();
        TransportadorModel BuscarPorID(int id);
        TransportadorModel Adicionar(TransportadorModel transportadorModel);
        TransportadorModel Atualizar(TransportadorModel transportadorModel);
        ICollection<TransportadorModel> BuscarTransportador(int[] selectedTransportadorIds);
        bool Apagar(int id);
        TransportadorModel BuscarPorUsuario(int idUsuario);
    }


}
