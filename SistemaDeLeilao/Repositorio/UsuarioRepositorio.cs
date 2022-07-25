using SistemaDeLeilao.Data;
using SistemaDeLeilao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContent _context;

        public UsuarioRepositorio(BancoContent bancoContent)
        {
            this._context = bancoContent;
        }
       
        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarios = BuscarPorID(usuario.Id);
            usuario.DataCadastro = usuarios.DataCadastro;

            if (usuario == null) throw new Exception("Houve um erro na atualização do Funcionario!");

            _context.Usuario.Update(usuario);
            _context.SaveChanges();

            return usuarios;
        }

        public UsuarioModel BuscarPorID(int id)
        {
            return _context.Usuario.FirstOrDefault(x => x.Id == id);
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuario.FirstOrDefault(x => x.Login == login);
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarios = BuscarPorID(id);

            if (usuarios == null) return false;
            _context.Usuario.Remove(usuarios);
            _context.SaveChanges();
            return true;
        }
    }
}
