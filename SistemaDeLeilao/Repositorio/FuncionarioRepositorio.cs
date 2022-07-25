using SistemaDeLeilao.Data;
using SistemaDeLeilao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeLeilao.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly BancoContent _context;

        public FuncionarioRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }

        public FuncionarioModel BuscarPorID(int id)
        {
            return _context.Funcionarios
                .Include(x => x.Usuario)
                .Include(x => x.Embarcadores)
                .FirstOrDefault(x => x.Id == id);
        }

        public FuncionarioModel BuscarPorIDUsuario(int id)
        {
            return _context.Funcionarios
                .Include(x => x.Usuario)
                .Include(x => x.Embarcadores)
                .FirstOrDefault(x => x.Usuario.Id == id);
        }

        public List<FuncionarioModel> BuscarTodos()
        {
            return _context.Funcionarios
                .Include(x => x.Usuario)
                .Include(x => x.Embarcadores)
                .ToList();
        }

        public List<FuncionarioModel> BuscarFuncionariosEmbarcador(int idEmbarcador)
        {
            return _context.Funcionarios
                .Include(x => x.Embarcadores).ToList()
                .Where(x => x.Embarcadores.Id == idEmbarcador).ToList();
        }

        public FuncionarioModel Adicionar(FuncionarioModel Funcionario)
        {
            Funcionario.DataCadastro = DateTime.Now;
            Funcionario.Usuario.DataAtualizacao = DateTime.Now;
            Funcionario.Usuario.SetSenhaHash();

            _context.Funcionarios.Add(Funcionario);
            _context.SaveChanges();
            return Funcionario;
        }

        public FuncionarioModel Atualizar(FuncionarioModel Funcionario)
        {
            FuncionarioModel FuncionarioDB = BuscarPorID(Funcionario.Id);

            if (FuncionarioDB == null) throw new Exception("Houve um erro na atualização do Funcionario!");

            FuncionarioDB.DataAtualizacao = DateTime.Now;
            FuncionarioDB.Nome = Funcionario.Nome;
            FuncionarioDB.Usuario.DataAtualizacao = DateTime.Now;
            FuncionarioDB.Usuario = Funcionario.Usuario;
            FuncionarioDB.Usuario.SetSenhaHash();
            FuncionarioDB.Usuario = Funcionario.Usuario;
            _context.Funcionarios.Update(FuncionarioDB);
            _context.SaveChanges();

            return FuncionarioDB;
        }

        public bool Apagar(int id)
        {
            FuncionarioModel FuncionarioDB = BuscarPorID(id);

            if (FuncionarioDB == null) throw new Exception("Houve um erro na deleção do Funcionario!");

            _context.Usuario.Remove(FuncionarioDB.Usuario);
            _context.Funcionarios.Remove(FuncionarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
