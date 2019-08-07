using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XPelum.ViewModel;

namespace XPelum.Factory
{
    public class UploadImageFactory
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadImageFactory(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;          
        }

        public string SalvarImagem(CreateAssessoriaViewModel assessoriaVM)
        {
            string pasta = Path.Combine(_hostingEnvironment.WebRootPath, "img"); //determina o diretório para salvar as imagens
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + assessoriaVM.Imagem.FileName; //criando um unico nome de imagem com GUID
            string diretorioDaImagem = Path.Combine(pasta, uniqueFileName); //combinando diretório da pasta com nome da imagem
            assessoriaVM.Imagem.CopyTo(new FileStream(diretorioDaImagem, FileMode.Create));

            return uniqueFileName;
        }
    }
}
