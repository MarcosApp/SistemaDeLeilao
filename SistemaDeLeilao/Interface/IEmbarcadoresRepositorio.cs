using SistemaDeLeilao.Models;
using System.Collections.Generic;

namespace SistemaDeLeilao.Repositorio
{
    public interface IEmbarcadoresRepositorio
    {
        List<EmbarcadoresModel> BuscarTodos();
        EmbarcadoresModel BuscarPorID(int id);
        EmbarcadoresModel Adicionar(EmbarcadoresModel Embarcadores);
        EmbarcadoresModel Atualizar(EmbarcadoresModel Embarcadores);
        bool Apagar (int id);
        List<EmbarcadoresModel> BuscarFuncionariosEmbarcador(int id);
        ICollection<EmbarcadoresModel> BuscarTransportador(int[] selectedEmbarcadoresIds);
    }
}
