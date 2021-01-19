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

        
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();

            Equipe equipe = new Equipe();

            ViewBag.Equipes = equipe.ReadAll();

            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();
            

            novoJogador.Nome = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.Senha = form["Senha"];

            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();

            return LocalRedirect("/Jogador");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            jogadorModel.Delete(id);

            ViewBag.Jogadores = jogadorModel.ReadAll();
            
            return LocalRedirect("/Jogador");
        }
    }
}