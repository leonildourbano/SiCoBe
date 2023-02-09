using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoSisConBens.Models
{
    public class Unidade
    {
        public int UnidadeId { get; set; }

        [Display(Name = "Identificação")]
        [Required(ErrorMessage = "É necessário digitar a Identificação da Unidade", AllowEmptyStrings = false)]
        public string UnidadeIdentificacao { get; set; }

        [Display(Name = "Atividades")]
        [Required(ErrorMessage = "É necessário informar a Atividade da Unidade", AllowEmptyStrings = false)]
        public string UnidadeAtividades { get; set; }

        [Display(Name = "Endereço")]
        public string UnidadeEndereco { get; set; }

        [Display(Name = "Bairro")]
        public string UnidadeBairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "É necessário informar a Cidade da Unidade", AllowEmptyStrings = false)]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }


        [Display(Name = "CEP")]
        public string UnidadeCep { get; set; }


        public ICollection<Bem> Bem { get; set; }
        public ICollection<Colaborador> Colaborador { get; set; }



    }
}
