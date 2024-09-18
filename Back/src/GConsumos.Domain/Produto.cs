using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}