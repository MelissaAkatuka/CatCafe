using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public class CadastroGato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "A espécie é obrigatória")]
        public String Especie { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]

        [DisplayName("É alugável")]
        public bool EhAlugavel { get; set; }
        [DisplayName("Está alugado")]
        public bool EstaAlugado { get; set; }
        public string Alugavel => EhAlugavel ? "Sim" : "Não";
    }
}
