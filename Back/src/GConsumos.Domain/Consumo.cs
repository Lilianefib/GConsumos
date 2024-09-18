using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Domain
{
    public class Consumo
    {
        public int Id { get; set; }
        public int MedidorId { get; set; }
        public Medidor Medidor { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int TotalConsumo { get; set; }
        public string Competencia { get; set; }
    }
}