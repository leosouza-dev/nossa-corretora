using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XPelum.Models;
using XPelum.Repository;

namespace XPelum.Controllers
{
    public class HomeController : Controller
    {
        private readonly AssessoriaRepository _repository;

        public HomeController(AssessoriaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            
            return View(_repository.ListarTodas());
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
