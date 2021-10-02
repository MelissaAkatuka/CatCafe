using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public class Repositorio : IRepositorio
    {
        //retorna lista de todas as cofirmações
        //guarda a lista de todas as submissões
        private static List<CadastroGato> gatos = new List<CadastroGato>();
        public static IEnumerable<CadastroGato> Gatos { get => gatos; }

        private static List<EmprestimoGato> emprestimos = new List<EmprestimoGato>();
        public static IEnumerable<EmprestimoGato> Emprestimos { get => emprestimos; }

        public static void AdicionaGato(CadastroGato cadastroGatos)
        {
            gatos.Add(cadastroGatos);
        }

        public static void AdicionaEmprestimo(EmprestimoGato emprestimo)
        {
            var gatoEmprestado = gatos.FirstOrDefault(x => x.Nome == emprestimo.NomeGato);
            gatoEmprestado.EstaAlugado = true;
            emprestimos.Add(emprestimo);
        }
    }
}
