using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dangerouswildcats.Models
{
    public class JogoReciclagem : IComparable
    {
        public int ID { get; set; }
        public int Nivel { get; set; }        
        public int TotalMaterialReciclado { get; set; }
        public int TotalMaterialNivel { get; set; }
        public string UltimoTipoUitilizado { get; set; }
        public string UsernameJogador { get; set; }

        private int m_numMaterial;

        [Required(ErrorMessage = "Introduza uma quantidade de embalagens de plástico válida!")]

        [Range(0, 100)]

        public int NumMaterial
        {
            get { return m_numMaterial; }
            set
            {
                if (value >= 0)
                {
                    m_numMaterial = value;
                }
            }
        }

        public int CompareTo(object obj)
        {
            JogoReciclagem jr = (JogoReciclagem)obj;

            return jr.TotalMaterialReciclado.CompareTo(TotalMaterialReciclado);
        }
    }
}

