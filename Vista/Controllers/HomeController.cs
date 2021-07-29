using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vista.Models;
using Newtonsoft.Json;
using DaoRepository;
using Services;

namespace Vista.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            InyectarDependencias di = new InyectarDependencias();
            di.InyectarDepencias();

            usuarios_dao dao = new usuarios_dao();
            IEnumerable<usuarios_dto> dtos = new List<usuarios_dto>();
            dtos = dao.Obtener();
            return View(dtos);
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

        [HttpGet]
        public IActionResult Edit(string rut)
        {
            usuarios_dao dao = new usuarios_dao();
            IEnumerable<usuarios_dto> dtos = new List<usuarios_dto>();
            usuarios_dto dto = new usuarios_dto();
            dtos = dao.Obtener(rut);
            foreach(var dato in dtos)
            {
                dto = dato;
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(usuarios_dto dto)
        {
            usuarios_dao dao = new usuarios_dao();
            dao.Guardar(dto);
            return RedirectToAction("Index");
        }

    }
}
