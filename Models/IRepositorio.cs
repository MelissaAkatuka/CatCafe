using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public interface IRepositorio
    {
        static  List<CadastroGato> gatos { get; set; }
        static IEnumerable<CadastroGato> Gatos { get; set; }

        static List<EmprestimoGato> emprestimos { get; set; }
        static IEnumerable<EmprestimoGato> Emprestimos { get; }

        void AdicionaGato(CadastroGato cadastroGatos) {}

        void AdicionaEmprestimo(EmprestimoGato emprestimo) {}
    }
}
