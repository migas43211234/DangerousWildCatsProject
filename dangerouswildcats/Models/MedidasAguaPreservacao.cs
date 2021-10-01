using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dangerouswildcats.Models
{
    public class MedidasAguaPreservacao: IComparable

    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Introduza um nome válido!")]
        public string NomeMedida { get; set; }

        [Required(ErrorMessage = "Introduza uma descrição válida!")]
        public string Descricao { get; set; }

        
        [Required(ErrorMessage = "Introduza uma imagem válida!")]
        [Display(Name = "Imagem alusiva à Medida")] 
 

        [NotMapped]
        public IFormFile Figura { get; set; }
        public string URLFicheiro { get; set; }
        public bool Aprovacao { get; set; }

        public int CompareTo(object medida)
        {
            MedidasAguaPreservacao a = (MedidasAguaPreservacao)medida;
            if (a.Aprovacao == Aprovacao)
                return 0;
            else if (a.Aprovacao = !Aprovacao)
                return -1;
            else
                return 1;
        }

    }
}
