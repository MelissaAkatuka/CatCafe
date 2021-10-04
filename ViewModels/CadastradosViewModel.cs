using CatCafe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.ViewModels
{
    public class CadastradosViewModel
    {
        [DisplayName("Buscar por nome")]
        public String Search { get; set; }
        public IEnumerable<CadastroGato> Cadastrados { get; set; }
    }
}
