using System;
using EPlayers_ASPNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_ASPNETCore.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.IdJogador = Int32.Parse( form["IdJogador"] );
            novoJogador.Nome = form["Nome"];
            novoJogador.IdEquipe = Int32.Parse( form["IdEquipe"] );

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            jogadorModel.Delete(id);

            ViewBag.Jogadores = jogadorModel.ReadAll();
            
            return LocalRedirect("~/Jogador/Listar");
        }
    }
}