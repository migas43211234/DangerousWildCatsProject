using System;
using System.ComponentModel.DataAnnotations;

namespace dangerouswildcats.Models
{
    public class Voluntariado : IComparable
    {
        public int ID { get; set; } 
        [Required(ErrorMessage ="Introduza um Nome válido!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza uma data de nascimento válida!")]
        [Range(typeof(DateTime), "01/01/1910", "01/01/2015", ErrorMessage = "O voluntário deve ter mais de 6 anos")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Introduza um NIF com um máximo de 9 caracteres!")]
        public int? NIF { get; set; }

        [Required(ErrorMessage = "Introduza um e-mail válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza um Número de Telemóvel válido!")]
        public int? NumTelemovel { get; set; }
        public string Morada { get; set; }

        [Required(ErrorMessage = "Introduza um Código Postal válido!")]
        public string CodigoPostal { get; set; }
        [Required(ErrorMessage = "Introduza uma Localidade válida!")]
        public string Localidade { get; set; }
        public string Disponibilidade { get; set; }
        public string SobreMim { get; set; }

        public int CompareTo(object nome)
        {
            Voluntariado v = (Voluntariado)nome;
            return Nome.CompareTo(v.Nome);
        }

    }
}
