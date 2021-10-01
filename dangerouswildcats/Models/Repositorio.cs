using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dangerouswildcats.Models
{
    public static class Repositorio
    {
        public static List<Voluntariado> Voluntarios
        {
            get
            {
                DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
                List<Voluntariado> voluntarios = context.Voluntarios.ToList();
                return voluntarios;
            }
        }
        public static List<MedidasAguaPreservacao> Medidas
        {
            get
            {
                DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
                List<MedidasAguaPreservacao> medidas = context.Medidas.ToList();
                return medidas;
            }
        }
        public static List<JogoReciclagem> Jogadores
        {
            get
            {
                DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
                List<JogoReciclagem> jogadores = context.Jogadores.ToList();
                return jogadores;
            }
        }
        public static List<AnimaisExtincao> Animal
        {
            get
            {
                DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
                List<AnimaisExtincao> animal = context.Animal.ToList();
                return animal;
            }
        }
        public static List<CalendarioVoluntariado> CalendarioVoluntariado
        {
            get
            {
                DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
                List<CalendarioVoluntariado> calendario = context.Calendario.ToList();
                return calendario;
            }
        }
        public static List<AnimaisExtincaoOceano> AnimalOceano
        {
            get
            {
                DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
                List<AnimaisExtincaoOceano> animaloceano = context.AnimalOceano.ToList();
                return animaloceano;
            }
        }

        public static void AddVoluntarios(Voluntariado newVoluntariado)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Voluntarios.Add(newVoluntariado);
            context.SaveChanges();
        }

        public static void EditVoluntarios(int vol)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var voluntario = context.Voluntarios.Where(x => x.ID == vol).FirstOrDefault();
            context.SaveChanges();
        }
        public static void EditVoluntarios(Voluntariado voluntariado)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Voluntarios.Update(voluntariado);
            context.SaveChanges();
        }

        public static void ApagarVoluntarios(int vol)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var voluntario = context.Voluntarios.Where(x => x.ID == vol).FirstOrDefault();
            context.Voluntarios.Remove(voluntario);
            context.SaveChanges();
        }

        public static void ApagarTodosVoluntarios()
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Voluntarios.RemoveRange(context.Voluntarios);
            context.SaveChanges();
        }
        public static void AddMedidas(MedidasAguaPreservacao newMedidasAgua)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Medidas.Add(newMedidasAgua);
            context.SaveChanges();
        }
        public static void AddAnimal(AnimaisExtincao newAnimalExtincao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Animal.Add(newAnimalExtincao);
            context.SaveChanges();
        }
        public static void AddCalendarioVoluntariado(CalendarioVoluntariado newCalendarioVoluntariado)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Calendario.Add(newCalendarioVoluntariado);

            context.SaveChanges();
        }
        public static void AddAnimalOceano(AnimaisExtincaoOceano newAnimalExtincaoOceano)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.AnimalOceano.Add(newAnimalExtincaoOceano);
            context.SaveChanges();
        }
        public static JogoReciclagem GuardarJogo(JogoReciclagem newJogo)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            JogoReciclagem jogoBD = null;

            foreach (JogoReciclagem j in context.Jogadores)
            {
                if (j.UsernameJogador == newJogo.UsernameJogador)
                {
                    jogoBD = j;
                    jogoBD.UltimoTipoUitilizado = newJogo.UltimoTipoUitilizado;
                    break;
                }
            }

            if (jogoBD is null)
            {
                newJogo.Nivel = 1;
                newJogo.TotalMaterialNivel = 0;
                context.Jogadores.Add(newJogo);
                jogoBD = newJogo;
            }
            else
            {

                jogoBD.NumMaterial = newJogo.NumMaterial;
                context.Jogadores.Update(jogoBD);

            }

            jogoBD.TotalMaterialReciclado = jogoBD.TotalMaterialReciclado + jogoBD.NumMaterial;
            jogoBD.TotalMaterialNivel = jogoBD.TotalMaterialNivel + jogoBD.NumMaterial;

            while ((jogoBD.TotalMaterialNivel > 100))
            {

                jogoBD.TotalMaterialNivel = jogoBD.TotalMaterialNivel - 100;
                jogoBD.Nivel = jogoBD.Nivel + 1;

            } 

            context.SaveChanges();

            return (jogoBD);
        }

        public static JogoReciclagem LocalizarJogador(JogoReciclagem jogador)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            JogoReciclagem jogoBD = null;

            foreach (JogoReciclagem jr in context.Jogadores)
            {
                if (jr.UsernameJogador == jogador.UsernameJogador)
                {

                    jogoBD = jr;
                    break;

                }
            }

            return (jogador);

        }


        public static void EditAnimalExtincao(AnimaisExtincao animaisExtincao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Animal.Update(animaisExtincao);
            context.SaveChanges();
        }
        //alterar AQUI
        public static void AprovacaoAnimalExtincao(int ID, bool Aprovacao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var animal = context.Animal.Where(x => x.ID == ID).FirstOrDefault();
            animal.Aprovacao = Aprovacao;
            context.Animal.Update(animal);
            context.SaveChanges();
        }

        public static void ApagarAnimalExtincao(int ID)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var animal = context.Animal.Where(x => x.ID == ID).FirstOrDefault();
            context.Animal.Remove(animal);
            context.SaveChanges();
        }

        public static void EditAnimalOceano(AnimaisExtincaoOceano animaisExtincaoOceano)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.AnimalOceano.Update(animaisExtincaoOceano);
            context.SaveChanges();
        }
        public static void AprovacaoAnimalOceano(int ID, bool Aprovacao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var animal = context.AnimalOceano.Where(x => x.ID == ID).FirstOrDefault();
            animal.Aprovacao = Aprovacao;
            context.AnimalOceano.Update(animal);
            context.SaveChanges();
        }

        public static void ApagarAnimalOceano(int ID)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var animalOceano = context.AnimalOceano.Where(x => x.ID == ID).FirstOrDefault();
            context.AnimalOceano.Remove(animalOceano);
            context.SaveChanges();
        }
        public static void EditMedida(MedidasAguaPreservacao medidasAguaPreservacao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Medidas.Update(medidasAguaPreservacao);
            context.SaveChanges();
        }

        public static void AprovacaoMedida(int ID, bool Aprovacao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var medida = context.Medidas.Where(x => x.ID == ID).FirstOrDefault();
            medida.Aprovacao = Aprovacao;
            context.Medidas.Update(medida);
            context.SaveChanges();
        }


        public static void ApagarMedida(int medid)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var medida = context.Medidas.Where(x => x.ID == medid).FirstOrDefault();
            context.Medidas.Remove(medida);
            context.SaveChanges();
        }
        public static void EditCalendario(CalendarioVoluntariado calendarioVoluntariado)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            context.Calendario.Update(calendarioVoluntariado);
            context.SaveChanges();
        }
        public static void AprovacaoCalendario(int ID, bool Aprovacao)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var calendario = context.Calendario.Where(x => x.ID == ID).FirstOrDefault();
            calendario.Aprovacao = Aprovacao;
            context.Calendario.Update(calendario);
            context.SaveChanges();
        }

        public static void ApagarCalendario(int calend)
        {
            DangerousWildcatsDbContext context = new DangerousWildcatsDbContext();
            var calendar = context.Calendario.Where(x => x.ID == calend).FirstOrDefault();
            context.Calendario.Remove(calendar);
            context.SaveChanges();
        }
    }
}
