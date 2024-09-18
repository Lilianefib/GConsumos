using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GConsumos.Application.Dtos
{
    public class MedidorDto
    {
        public int Id { get; set; }
        public string numeroMedidor { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public string Tipo { get; set; }
        public string Localizacao { get; set; }
        public string Unidade { get; set; } 
    }
}