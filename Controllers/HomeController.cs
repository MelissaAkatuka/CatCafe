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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CadastroGato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroGato(CadastroGato cadastroGato)
        {
            //if(cadastroGatos.EhAlugavel != null)
            //{
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                Repositorio.AdicionaGato(cadastroGato);
                return RedirectToAction("Index");
            }

            return View(cadastroGato);
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
            {
                return new SelectListItem() { Text = x.Nome, Value = x.Id.ToString() };
            });

            ViewBag.bagListaGatos = listaGatos;

            return View();
        }

        [HttpPost]
        public IActionResult EmprestimoGato(EmprestimoGato emprestimo)
        {
            if (ModelState.IsValid)
            {
                Repositorio.AdicionaEmprestimo(emprestimo);
                return RedirectToAction("Index");
            }

            var listaGatos = Repositorio.Gatos.Where(x => x.EhAlugavel == true && x.EstaAlugado == false).Select(x =>
            {
                return new SelectListItem() { Text = x.Nome, Value = x.Id.ToString() };
            });

            ViewBag.bagListaGatos = listaGatos;
            return View(emprestimo);
        }

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
