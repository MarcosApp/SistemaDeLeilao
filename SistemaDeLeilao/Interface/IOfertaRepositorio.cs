using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Interface
{
    public interface IOfertaRepositorio
    {
        List<OfertaViewModel> BuscarTodos();
        bool Apagar(int id);
        OfertaModel BuscarPorID(int id);
        OfertaModel Adicionar(OfertaModel oferta);
        OfertaModel Atualizar(OfertaModel oferta);
    }
}
