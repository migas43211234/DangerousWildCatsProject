using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dangerouswildcats.Models
{
    public class DangerousWildcatsDbContext : DbContext
    {
        public DbSet<Voluntariado> Voluntarios { get; set; }
        public DbSet<MedidasAguaPreservacao> Medidas { get; set; }
        public DbSet<JogoReciclagem> Jogadores { get; set; }
        public DbSet<AnimaisExtincao> Animal { get; set; }
        public DbSet<CalendarioVoluntariado> Calendario { get; set; }
        public DbSet<AnimaisExtincaoOceano> AnimalOceano { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connection = @"Server=(localdb)\mssqllocaldb;Database=LW_2021_DWC; Trusted_Connection=True;";optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connection);

        }

    }
}

