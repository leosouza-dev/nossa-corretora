using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using XPelum.Models;
using XPelum.Repository;

namespace XPelum.Controllers
{
    public class HomeController : Controller
    {
        private readonly AssessoriaRepository _repository;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(AssessoriaRepository repository, IStringLocalizer<HomeController> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Mensagem"] = _localizer["TESTEE"];
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
