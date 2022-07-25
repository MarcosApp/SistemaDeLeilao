using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Repositorio
{
    public interface IUsuarioRepositorio 
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorID(int id);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel Adicionar(UsuarioModel Embarcadores);
        UsuarioModel Atualizar(UsuarioModel Embarcadores);
        bool Apagar(int id);
    }
}
