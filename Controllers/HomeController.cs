using CatCafe.Models;
using Microsoft.AspNetCore.Mvc;
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
