using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dangerouswildcats.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace dangerouswildcats.Controllers
{
    public class ConteudosController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment;
        public ConteudosController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        public IActionResult Agua()
        {
            return View();
        }
        public IActionResult AguaProblematica()
        {
            return View();
        }
        public IActionResult AguaPreservacao()
        {
            List<MedidasAguaPreservacao> medida = Repositorio.Medidas;
            return View(medida);
        }

        [Authorize]
        [HttpGet]
        public IActionResult NovaMedida()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovaMedida(MedidasAguaPreservacao medida)
        {
            {
                if (medida.Figura != null)
                {
                    string newFileName = "recursos/Agua/Preservacao/";    //Cria um novo nome de ficheiro da figura
                    newFileName += Guid.NewGuid().ToString() + "_" + medida.Figura.FileName;
                    string path = Path.Combine(hostingEnvironment.WebRootPath, newFileName);

                    medida.URLFicheiro = newFileName;

                    medida.Figura.CopyToAsync(new FileStream(path, FileMode.Create));
                }
            }
            if (ModelState.IsValid)
            {
                Repositorio.AddMedidas(medida);
                return View("ConfirmacaoMedida", medida);
            }
            return View();
        }
        public IActionResult Floresta()
        {
            return View();
        }
        public IActionResult Oceanos()
        {
            List<AnimaisExtincaoOceano> animalOceano = Repositorio.AnimalOceano;
            return View(animalOceano);
        }
        public IActionResult VidaSelvagem()
        {
            List<AnimaisExtincao> animal = Repositorio.Animal;
            return View(animal);
        }

        [Authorize]
        [HttpGet]
        public IActionResult NovoAnimal()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovoAnimal(AnimaisExtincao animal)
        {
            {
                if (animal.Figura != null)
                {
                    string newFileName = "recursos/VidaSelvagem";    //Cria um novo nome de ficheiro da figura
                    newFileName += Guid.NewGuid().ToString() + "_" + animal.Figura.FileName;
                    string path = Path.Combine(hostingEnvironment.WebRootPath, newFileName);

                    animal.URLFicheiro = newFileName;

                    animal.Figura.CopyToAsync(new FileStream(path, FileMode.Create));
                }
            }
            if (ModelState.IsValid)
            {
                Repositorio.AddAnimal(animal);
                return View("ConfirmacaoAnimal", animal);
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult NovoAnimalOceano()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult NovoAnimalOceano(AnimaisExtincaoOceano animalOceano)
        {
            {
                if (animalOceano.Figura != null)
                {
                    string newFileName = "recursos/Oceanos";    //Cria um novo nome de ficheiro da figura
                    newFileName += Guid.NewGuid().ToString() + "_" + animalOceano.Figura.FileName;
                    string path = Path.Combine(hostingEnvironment.WebRootPath, newFileName);

                    animalOceano.URLFicheiro = newFileName;

                    animalOceano.Figura.CopyToAsync(new FileStream(path, FileMode.Create));
                }

            }
            if (ModelState.IsValid)
            {
                Repositorio.AddAnimalOceano(animalOceano);
                return View("ConfirmacaoAnimalOceano", animalOceano);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Clima()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Clima(string cidade)
        {

            HttpClient client = MyHTTPClient.Client;


            string path = "v2.0/current/airquality?key=03fcdc8d91b44ae880038d7d3e35ae22&city=" + cidade;
            HttpResponseMessage response = client.GetAsync(path).Result;
            string myJsonResponse = await response.Content.ReadAsStringAsync();
            QualidadeArApi apiResponse = JsonConvert.DeserializeObject<QualidadeArApi>(myJsonResponse);

            return View(apiResponse);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListaAnimaisExtincao()
        {
            List<AnimaisExtincao> animaisExtincao = Repositorio.Animal;
            animaisExtincao.Sort();
            return View(animaisExtincao);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditAnimalExtincao(int ID, string NomeAnimal, string Aprovacao)
        {
            if (Aprovacao != null)
                Repositorio.AprovacaoAnimalExtincao(ID, true);
            else
                Repositorio.AprovacaoAnimalExtincao(ID, false);
            List<AnimaisExtincao> animalExtincao = Repositorio.Animal;
            animalExtincao.Sort();


            return View("ListaAnimaisExtincao", animalExtincao);
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAnimalExtincao(int id)
        {
            Repositorio.ApagarAnimalExtincao(id);
            List<AnimaisExtincao> animalExtincao = Repositorio.Animal;
            animalExtincao.Sort();
            return View("ListaAnimaisExtincao", animalExtincao);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListaAnimaisExtincaoOceanos()
        {
            List<AnimaisExtincaoOceano> animaisExtincaoOceano = Repositorio.AnimalOceano;
            animaisExtincaoOceano.Sort();
            return View(animaisExtincaoOceano);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditAnimalOceano(int ID, string Nome, string Aprovacao)
        {
            if (Aprovacao != null)
                Repositorio.AprovacaoAnimalOceano(ID, true);
            else
                Repositorio.AprovacaoAnimalOceano(ID, false);
            List<AnimaisExtincaoOceano> animalExtincaoOceano = Repositorio.AnimalOceano;
            animalExtincaoOceano.Sort();

            return View("ListaAnimaisExtincaoOceanos", animalExtincaoOceano);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAnimalOceano(int ID)
        {
            Repositorio.ApagarAnimalOceano(ID);
            List<AnimaisExtincaoOceano> animalExtincaoOceano = Repositorio.AnimalOceano;
            animalExtincaoOceano.Sort();
            return View("ListaAnimaisExtincaoOceanos", animalExtincaoOceano);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListaMedidas()
        {
            List<MedidasAguaPreservacao> medidas = Repositorio.Medidas;
            medidas.Sort();
            return View(medidas);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditMedida(int ID, string NomeMedida, string Aprovacao)
        {
        
            if (Aprovacao != null)
                Repositorio.AprovacaoMedida(ID, true);
            else
                Repositorio.AprovacaoMedida(ID, false);
            List<MedidasAguaPreservacao> medidas = Repositorio.Medidas;
            medidas.Sort();


            return View("ListaMedidas", medidas);

        }
        

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteMedida(int id)
        {
            Repositorio.ApagarMedida(id);
            List<MedidasAguaPreservacao> medidas = Repositorio.Medidas;
            medidas.Sort();
            return View("ListaMedidas", medidas);
        }

        public IActionResult ConfirmacaoLista()
        {
            return View();
        }
    }
}
