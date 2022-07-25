using SistemaDeLeilao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Models
{
    public class LanceModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double? Preco { get; set; }
        public virtual TransportadorModel Transportador { get; set; }
        public virtual OfertaModel Oferta { get; set; }
        public LanceEnum? Status { get; set; }
    }
}
