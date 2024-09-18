using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Domain
{
    public class Medicao
    {
        public int Id { get; set; }
        public int MedidorId { get; set; }
        public DateTime DataMedicao { get; set; }
        public int leitura { get; set; }
    }
}