using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoSisConBens.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "É necessário especificar o nome da Cidade", AllowEmptyStrings = false)]
        public string CidadeNome { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "É necessário especificar a UF", AllowEmptyStrings = false)]
        [StringLength(2, MinimumLength = 2)]
        public string CidadeUf { get; set; }


        public ICollection<Unidade> Unidade { get; set; }

    }
}
