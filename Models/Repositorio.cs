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
        public static void AdicionaGato(CadastroGatos cadastroGatos)
        {
            gatos.Add(cadastroGatos);
        }
    }
}
