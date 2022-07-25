using SistemaDeLeilao.Models;
using SistemaDeLeilao.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaDeLeilao.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do funcionario")]
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        public virtual EmbarcadoresModel Embarcadores { get; set; }
    }
}
