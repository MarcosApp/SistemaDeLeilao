using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Models
{
    public class TransportadorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Cidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
        public virtual ICollection<EmbarcadoresModel> Embarcadores { get; set; }
        [BindProperty]
        [NotMapped]
        public int[] SelectedEmbarcadoresIds { get; set; }
    }
}
