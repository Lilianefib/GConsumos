using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Domain
{
    public class Morador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Unidade { get; set; }
        public IEnumerable<MoradorMedidor> MoradorMedidor { get; set; }
    }
}