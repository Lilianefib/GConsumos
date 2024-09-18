using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Domain
{
    public class MoradorMedidor
    {
        public int MoradorId { get; set; }
        public Morador Morador { get; set; }
        public int MedidorId { get; set; }
        public Medidor Medidor { get; set; }
    }
}