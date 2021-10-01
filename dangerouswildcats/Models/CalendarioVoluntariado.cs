using System;
using System.ComponentModel.DataAnnotations;

namespace dangerouswildcats.Models
{
    public class CalendarioVoluntariado: IComparable
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public DateTime Data  { get; set; }
        public string Horario { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public bool Aprovacao { get; set; }

        public int CompareTo(object calendario)
        {
            CalendarioVoluntariado a = (CalendarioVoluntariado)calendario;
            if (a.Aprovacao == Aprovacao)
                return 0;
            else if (a.Aprovacao = !Aprovacao)
                return -1;
            else
                return 1;
        }
    }


}
