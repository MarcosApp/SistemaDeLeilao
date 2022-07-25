using SistemaDeLeilao.Models;
using System.Collections.Generic;

namespace SistemaDeLeilao.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        List<FuncionarioModel> BuscarTodos();
        FuncionarioModel BuscarPorID(int id);
        FuncionarioModel BuscarPorIDUsuario(int id);
        List<FuncionarioModel> BuscarFuncionariosEmbarcador(int id);
        FuncionarioModel Adicionar(FuncionarioModel Funcionario);
        FuncionarioModel Atualizar(FuncionarioModel Funcionario);
        bool Apagar (int id);
    }
}
