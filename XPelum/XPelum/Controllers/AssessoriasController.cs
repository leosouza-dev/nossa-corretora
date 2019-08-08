using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using XPelum.Data;
using XPelum.Factory;
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
