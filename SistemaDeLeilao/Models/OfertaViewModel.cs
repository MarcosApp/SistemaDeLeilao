using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeLeilao.Models
{
    public class OfertaViewModel
    {
        public int Id { get; set; }
        public string NomeOferta { get; set; }
        public string EnderecoColeta { get; set; }
        public string EnderecoEntrega { get; set; }
        public int Quantidade { get; set; }
        public LanceModel? Lance { get; set; }
    }
}
