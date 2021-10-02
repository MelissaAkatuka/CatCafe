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

        public IActionResult CadastroGatos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroGatos(CadastroGatos cadastroGatos)
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
            var cadastrados = Repositorio.Gatos.Where(x => x.EhAlugavel == true);
            return View(cadastrados);
        }

        public IActionResult EmpresteGatos()
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
        public IActionResult EmpresteGatos(EmpresteGatos emprestimo)
        {
            if (ModelState.IsValid)
            {
                Repositorio.EmprestaGato(emprestimo);
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
