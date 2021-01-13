using System;
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
            novaNoticia.Imagem = form["Imagem"];

            noticiaModel.Create(novaNoticia);
            ViewBag.Noticias = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticia/Listar");
        }
    }
}