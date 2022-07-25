using SistemaDeLeilao.Models;
using SistemaDeLeilao.Models;

namespace SistemaDeLeilao.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoEmbarcadores(UsuarioModel UsuarioModel);
        void RemoverSessaoEmbarcadores();
        UsuarioModel BuscarSessaoDoEmbarcadores();
    }
}
