using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dangerouswildcats.Models
{
    public class AnimaisExtincaoOceano: IComparable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Introduza um nome válido!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza uma descrição válida!")]
        public string Descricao { get; set; }

        
        [Required(ErrorMessage = "Introduza uma imagem válida!")]
        [Display(Name = "Imagem Animal")]

        [NotMapped]
        public IFormFile Figura { get; set; }
        public string URLFicheiro { get; set; }
        public bool Aprovacao { get; set; }

        public int CompareTo(object animalOceano)
        {
            AnimaisExtincaoOceano a = (AnimaisExtincaoOceano)animalOceano;
            if (a.Aprovacao == Aprovacao)
                return 0;
            else if (a.Aprovacao =! Aprovacao)
                return -1;
            else
                return 1;
        }
    }
}
