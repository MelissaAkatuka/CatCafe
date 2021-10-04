using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CatCafe.Models;

namespace CatCafe.ViewModels
{
    public class EmprestimosViewModel
    {
        [DisplayName("Digite um termo para busca")]
        public string Search { get; set; }
        public IEnumerable<EmprestimoGato> Emprestimos { get; set; }
    }
}
