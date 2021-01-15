using System;
using System.IO;
using EPlayers_ASPNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_ASPNETCore.Controllers
{
    [Route("Noticia")]
    public class NoticiaController : Controller
    {
        Noticia noticiaModel = new Noticia();
        
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticia novaNoticia = new Noticia();

            novaNoticia.IdNoticia = Int32.Parse( form["IdNoticia"] );
            novaNoticia.Titulo = form["Título"];
            novaNoticia.Texto = form["Texto"];


            if (form.Files.Count > 0 )
            {
                var file   = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" , folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaNoticia.Imagem = file.FileName;
            }
            else
            {
                novaNoticia.Imagem = "padrao.png";
            }

            noticiaModel.Create(novaNoticia);
            ViewBag.Noticias = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticia/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);

            ViewBag.Noticias = noticiaModel.ReadAll();
            
            return LocalRedirect("~/Noticia/Listar");
        }
    }
}