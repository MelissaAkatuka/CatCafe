using CatCafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace CatCafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorio _repositorio;

        public HomeController(ILogger<HomeController> logger) // IRepositorio repositorio)
        {
            _logger = logger;
            //_repositorio = repositorio;
        }

        public IActionResult CadastroGato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroGato(CadastroGato cadastroGatos)
        {
            //if(cadastroGatos.EhAlugavel != null)
            //{
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                Repositorio.AdicionaGato(cadastroGatos);
                return RedirectToAction("Index");
            }

            return View(cadastroGatos);
        }

        public IActionResult Cadastrados()
        {
            //retorna lista dos gatos
            var listaGatos = Repositorio.Gatos;

            return View(listaGatos);
        }

        public IActionResult EmprestimoGato()
        {
            //retorna lista dos gatos
            var listaGatos = Repositorio.Gatos.Where(x => x.EhAlugavel == true && x.EstaAlugado == false).Select(x =>
            {//seleciona os itens da lista
                return new SelectListItem() { Text = x.Nome, Value = x.Nome };
            });

            //coloca os itens na ViewBag da View,
            ViewBag.bagListaGatos = listaGatos;

            return View();
        }

        [HttpPost]
        public IActionResult EmprestimoGato(EmprestimoGato emprestimo)
        {
            var gatoEmprestado = Repositorio.Gatos.FirstOrDefault(x => x.Nome == emprestimo.NomeGato);

            if (ModelState.IsValid && gatoEmprestado != null)
            {
                Repositorio.AdicionaEmprestimo(emprestimo, gatoEmprestado);
                return RedirectToAction("Index");
            }

            var listaGatos = Repositorio.Gatos.Where(x => x.EhAlugavel == true && x.EstaAlugado == false).Select(x =>
            {
                return new SelectListItem() { Text = x.Nome, Value = x.Nome };
            });

            ViewBag.bagListaGatos = listaGatos;
            return View(emprestimo);
        }

        public IActionResult Emprestimos()
        {
            var emprestimos = Repositorio.Emprestimos;

            return View(emprestimos);
        }

        //public IActionResult EdicaoEmprestimo(int id)
        //{
        //    var editando = _repositorio.Emprestimos.FirstOrDefault(x => x.Id == id);
        //    if (editando == null)
        //        return RedirectToAction("Confirmados");

        //    return View(editando);
        //}

        //[HttpPost]
        //public IActionResult Edicao(Confirmacao confirmacao)
        //{
        //    _repositorio.Update(confirmacao);

        //    return RedirectToAction("Confirmados");
        //}


        //public IActionResult Remocao(int id)
        //{
        //    var removendo = _repositorio.Confirmacoes.FirstOrDefault(x => x.Id == id);
        //    if (removendo == null)
        //        return RedirectToAction("Confirmados");

        //    return View(removendo);
        //}

        //[HttpPost]
        //public IActionResult Remocao(Confirmacao confirmacao)
        //{
        //    _repositorio.Remove(confirmacao);

        //    return RedirectToAction("Confirmados");
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
