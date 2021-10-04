using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatCafe.Controllers;

namespace CatCafe.Models
{
    public class Repositorio : IRepositorio
    {
        //retorna lista de todas as cofirmações
        //guarda a lista de todas as submissões
        private static List<CadastroGato> gatos = new List<CadastroGato>()
        { 
            new CadastroGato
            {
                Id = 1,
                Nome = "Miau",
                Especie = "Siamês",
                EhAlugavel = true,
                EstaAlugado = false
            },
            new CadastroGato
            {
                Id = 2,
                Nome = "Clóvis",
                Especie = "SRD",
                EhAlugavel = true,
                EstaAlugado = true
            }

        };
        public static IEnumerable<CadastroGato> Gatos { get => gatos; }

        private static List<EmprestimoGato> emprestimos = new List<EmprestimoGato>()
        {
            new EmprestimoGato
            {
                NomeCliente = "Beatriz Resende",
                NomeGato = "Miau",
                EmailCliente = "bcastroresende@gmail.com",
                TelefoneCliente = "62 12345678",
                DataEmprestimo = DateTime.Now,
                DataDevolucao = Convert.ToDateTime("10/10/2021")
            }
        };
        public static IEnumerable<EmprestimoGato> Emprestimos { get => emprestimos; }

        public static void AdicionaGato(CadastroGato cadastroGatos)
        {
            gatos.Add(cadastroGatos);
        }

        public static void AdicionaEmprestimo(EmprestimoGato emprestimo, CadastroGato gatoEmprestado)
        {
            gatoEmprestado.EstaAlugado = true;
            emprestimos.Add(emprestimo);
        }
    }
}
