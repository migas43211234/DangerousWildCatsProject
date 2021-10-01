using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dangerouswildcats.Models;
using Microsoft.AspNetCore.Authorization;

namespace dangerouswildcats.Controllers
{
    public class ReciclagemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult MenuJogoReciclagem(JogoReciclagem jogador)
        {
            Repositorio.LocalizarJogador(jogador);
            return View(jogador);
        }

       
        [Authorize]
        public IActionResult JogoReciclagem(JogoReciclagem jogo)
        {
            if (ModelState.IsValid)
            {
                jogo = Repositorio.GuardarJogo(jogo);
                jogo.NumMaterial = 0;
                return View(jogo);
            }
            return View(jogo);
        }

        [Authorize]
        public IActionResult Opcoes()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult RankingJogo()
        {

            List<JogoReciclagem> jogoReciclagem = Repositorio.Jogadores;
            jogoReciclagem.Sort();
            return View(jogoReciclagem);

        }

        [Authorize]
        public IActionResult EstatisticasJogador(JogoReciclagem jogador)
        {
            jogador = Repositorio.LocalizarJogador(jogador);
            return View(jogador);
        }

    }
}
