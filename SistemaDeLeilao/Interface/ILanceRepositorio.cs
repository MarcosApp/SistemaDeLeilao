using SistemaDeLeilao.Models;
using System.Collections.Generic;

namespace SistemaDeLeilao.Controllers
{
    public interface ILanceRepositorio
    {
        List<LanceModel> BuscarTodos(int id);
        List<LanceModel> BuscarTodos();
        bool Apagar(int id);
        LanceModel BuscarPorID(int id);
        LanceModel Adicionar(LanceModel oferta);
        LanceModel Atualizar(LanceModel oferta);
        LanceModel BuscarPorOferta(int id);
    }
}