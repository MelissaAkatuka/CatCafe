using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public class EmprestimoGato
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "O email do cliente é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string EmailCliente { get; set;  }

        [Required(ErrorMessage = "O telefone do cliente é obrigatório")]
        public string TelefoneCliente { get; set; }

        [Required(ErrorMessage = "A seleção do gato é obrigatória")]
        public string NomeGato { get; set; }

        [Required(ErrorMessage = "A data de empréstimo é obrigatória")]
        public DateTime DataEmprestimo { get; set; }

        [Required(ErrorMessage = "A data para devolução é obrigatória")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de data inválido")]
        public DateTime DataDevolucao { get; set; }

        public DateTime? DataDevolvido { get; set; }
    }
}
