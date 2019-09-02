using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using XPelum.Components;
using XPelum.Models;
using XPelum.Repository;
using XPelum.ViewModel;

namespace XPelum.Controllers
{
    public class AssessoriasController : Controller
    {
        private readonly AssessoriaRepository _repository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AssessoriasController(AssessoriaRepository repository,
                                    IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Acessorias
        public IActionResult Index()
        {
            return View(_repository.ListarTodas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAssessoriaViewModel assessoriaVM)
        {
            if (ModelState.IsValid)
            {
                var uploadImage = new UploadImageComponent(_hostingEnvironment);
                var uniqueFileName = uploadImage.SalvaImagem(assessoriaVM.Imagem);

                var assessoria = new Assessoria(assessoriaVM.Nome, uniqueFileName, assessoriaVM.investimento, assessoriaVM.Descricao);

                _repository.Salvar(assessoria);
                return RedirectToAction(nameof(Index));
            }
            return View(assessoriaVM);
        }

    }
}
