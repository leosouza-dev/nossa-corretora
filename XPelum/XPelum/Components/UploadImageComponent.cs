using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace XPelum.Components
{
    public class UploadImageComponent
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadImageComponent(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;          
        }

        public string SalvaImagem(IFormFile Imagem)
        {
            string pasta = Path.Combine(_hostingEnvironment.WebRootPath, "img"); //determina o diretório para salvar as imagens
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Imagem.FileName; //criando um unico nome de imagem com GUID
            string diretorioDaImagem = Path.Combine(pasta, uniqueFileName); //combinando diretório da pasta com nome da imagem
            Imagem.CopyTo(new FileStream(diretorioDaImagem, FileMode.Create));

            return uniqueFileName;
        }
    }
}
