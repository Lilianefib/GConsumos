using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Domain
{
    public class Medidor
    {
        public int Id { get; set; }
        public string numeroMedidor { get; set; }
        public string Tipo { get; set; }
        public string Localizacao { get; set; }
        public string Unidade { get; set; }
        
    }
}