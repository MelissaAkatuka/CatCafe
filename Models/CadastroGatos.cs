using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public class CadastroGatos
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "A espécie é obrigatória")]
        public String Especie { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public bool EhAlugavel { get; set; }
        public bool EstaAlugado { get; set; }
    }
}
