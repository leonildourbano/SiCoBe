using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoSisConBens.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }

        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "É obrigatório informar a Matrícula do Colaborador", AllowEmptyStrings = false)]
        public string ColaboradorRegistrofuncional { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "É obrigatório informar o Nome do Colaborador", AllowEmptyStrings = false)]
        public string ColaboradorNome { get; set; }

        [Display(Name = "RG")]
        public string ColaboradorRg { get; set; }

        [Display(Name = "CPF")]
        public string ColaboradorCpf { get; set; }


        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "É obrigatório informar o Cargo do Colaborador", AllowEmptyStrings = false)]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }


        [Display(Name = "Unidade de Lotação")]
        [Required(ErrorMessage = "É obrigatório informar a Unidade do Colaborador", AllowEmptyStrings = false)]
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }

    }
}