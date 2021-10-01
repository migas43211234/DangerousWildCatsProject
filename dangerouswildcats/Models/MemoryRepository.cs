using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dangerouswildcats.Models
{
    public static class MemoryRepository
    {
        private static List<Voluntariado> voluntarios = new List<Voluntariado>();
        private static List<MedidasAguaPreservacao> medidas = new List<MedidasAguaPreservacao>();
        //private static List<JogoReciclagem> jogadores = new List<JogoReciclagem>();
        private static List<AnimaisExtincao> animal = new List<AnimaisExtincao>();
        private static List<CalendarioVoluntariado> calendario = new List<CalendarioVoluntariado>();
        private static List<AnimaisExtincaoOceano> animalOceano = new List<AnimaisExtincaoOceano>();

        public static List<Voluntariado> Voluntarios  
        {
            get
            {
                return voluntarios;
            }
        }

        public static List<MedidasAguaPreservacao> Medidas
        {
            get
            {
                return medidas;
            }
        }

        //public static List<JogoReciclagem> Jogadores
        //{
        //    get
        //    {
        //        return jogadores;
        //    }
        //}

        public static List<AnimaisExtincao> Animal
        {
            get
            {
                return animal;
            }
        }
        public static List<CalendarioVoluntariado> CalendarioVoluntariado
        {
            get
            {
                return calendario;
            }
        }

        public static List<AnimaisExtincaoOceano> AnimalOceano
        {
            get
            {
                return animalOceano;
            }
        }
        public static void AddVoluntarios(Voluntariado voluntariado)
        {
            voluntarios.Add(voluntariado);
        }

        public static void AddMedidas(MedidasAguaPreservacao medidasAgua)
        {
            medidas.Add(medidasAgua);
        }
        public static void AddAnimal(AnimaisExtincao animalExtincao)
        {
            animal.Add(animalExtincao);
        }
        public static void AddCalendarioVoluntariado(CalendarioVoluntariado calendarioVoluntariado)
        {
            calendario.Add(calendarioVoluntariado);
        }
        public static void AddAnimalOceano(AnimaisExtincaoOceano animalExtincaoOceano)
        {
            animalOceano.Add(animalExtincaoOceano);
        }
    }
}
