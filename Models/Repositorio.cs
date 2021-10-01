using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public class Repositorio
    {
        //retorna lista de todas as cofirmações
        //guarda a lista de todas as submissões
        private static List<CadastroGatos> gatos = new List<CadastroGatos>();
        public static IEnumerable<CadastroGatos> Gatos { get => gatos; }

        private static List<EmpresteGatos> emprestimos = new List<EmpresteGatos>();
        public static IEnumerable<EmpresteGatos> Emprestimos { get => emprestimos; }
        public static void AdicionaGato(CadastroGatos cadastroGatos)
        {
            gatos.Add(cadastroGatos);
        }

        public static void EmprestaGato(EmpresteGatos emprestimo)
        {
            var gatoEmprestado = gatos.FirstOrDefault(x => x.Nome == emprestimo.NomeGato);
            gatoEmprestado.EstaAlugado = true;
        }

        public static void AdicionaEmprestimo(EmpresteGatos emprestimo)
        {
            emprestimos.Add(emprestimo);
        }
    }
}
