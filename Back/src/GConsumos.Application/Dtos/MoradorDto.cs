using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Application.Dtos
{
    public class MoradorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage ="O campo {0} precisa ser válido.")]
        public string Email { get; set; }
        [Phone(ErrorMessage ="O campo {0} está com número inválido.")]
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Unidade { get; set; }
       // public IEnumerable<MoradorMedidor> MoradorMedidor { get; set; }
        
    }
}