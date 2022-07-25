
using SistemaDeLeilao.Enums;
using SistemaDeLeilao.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeLeilao.Models
{
    public class EmbarcadoresModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        public virtual ICollection<TransportadorModel> Transportador { get; set; }
        [BindProperty]
        [NotMapped]
        public int[] SelectedTransportadorIds { get; set; }

    }
}
