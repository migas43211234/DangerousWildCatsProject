using dangerouswildcats.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace dangerouswildcats.Controllers
{
    public class VoluntariadoController : Controller
    {
        public IActionResult Index()
        {
            List<CalendarioVoluntariado> calendarioVoluntariado = Repositorio.CalendarioVoluntariado;

            List<Voluntariado> voluntariado = Repositorio.Voluntarios;
            return View(calendarioVoluntariado);

        }

        [Authorize]
        [HttpGet]
        public IActionResult NovoVoluntario()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovoVoluntario(Voluntariado voluntariado)
        {
            if (ModelState.IsValid)
            {
                Repositorio.AddVoluntarios(voluntariado);
                return View("ConfirmacaoVoluntario", voluntariado);
            }
            return View();
            
        }

        [Authorize]
        [HttpGet]
        public IActionResult NovoEvento()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovoEvento(string Titulo, DateTime Data, string Horario, string Descricao, string Local)
        {
            CalendarioVoluntariado calendarioVoluntariado = new CalendarioVoluntariado();

            calendarioVoluntariado.Titulo = Titulo;
            calendarioVoluntariado.Data = Data;
            calendarioVoluntariado.Horario = Horario;
            calendarioVoluntariado.Descricao = Descricao;
            calendarioVoluntariado.Local = Local;
            //calendarioVoluntariado.Aprovacao = true;

            Repositorio.AddCalendarioVoluntariado(calendarioVoluntariado);
            return View("ConfirmacaoEvento", calendarioVoluntariado);

        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult ListaVoluntarios()
        {
            List<Voluntariado> voluntariado = Repositorio.Voluntarios;
            voluntariado.Sort();
            return View(voluntariado);     
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditVoluntarios(int id)
        {
            Repositorio.EditVoluntarios(id);
            Voluntariado voluntario = Repositorio.Voluntarios.Find(x => x.ID == id);
            return View(voluntario);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditVoluntarios(Voluntariado voluntariado)
        {

            if (ModelState.IsValid)
            {
                Repositorio.EditVoluntarios(voluntariado);
                return View("ConfirmacaoEditVoluntarios", voluntariado);
            }
            return View(voluntariado);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteVoluntarios(int id)
        {
            Repositorio.ApagarVoluntarios(id);
            List<Voluntariado> voluntariado = Repositorio.Voluntarios;
            voluntariado.Sort();
            return View("ListaVoluntarios", voluntariado);          
        }

        [Authorize(Roles ="Admin")]
        public IActionResult DeleteAllVoluntarios()
        {
            Repositorio.ApagarTodosVoluntarios();
            List<Voluntariado> voluntariado = Repositorio.Voluntarios;
            return View("ListaVoluntarios", voluntariado);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListaCalendario()
        {
            List<CalendarioVoluntariado> calendarioVoluntariado = Repositorio.CalendarioVoluntariado;
            return View(calendarioVoluntariado);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCalendario(int ID, string Local, string Aprovacao)
        {
            if (Aprovacao != null)
                Repositorio.AprovacaoCalendario(ID, true);
            else
                Repositorio.AprovacaoCalendario(ID, false);
            List<CalendarioVoluntariado> calendarioVoluntariado = Repositorio.CalendarioVoluntariado;
            calendarioVoluntariado.Sort();


            return View("ListaCalendario", calendarioVoluntariado);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteCalendario(int id)
        {
            Repositorio.ApagarCalendario(id);
            List<CalendarioVoluntariado> calendarioVoluntariado = Repositorio.CalendarioVoluntariado;
            calendarioVoluntariado.Sort();
            return View("ListaCalendario", calendarioVoluntariado);
        }

    }

}
