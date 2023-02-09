using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoSisConBens.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "É necessário especificar o Cargo", AllowEmptyStrings = false)]
        public string CargoDescricao { get; set; }

        [Display(Name = "Instrução mínima")]
        [Required(ErrorMessage = "É necessário especificar a Instrução mínima para o Cargo", AllowEmptyStrings = false)]
        public string CargoInstrucao { get; set; }

        public ICollection<Colaborador> Colaborador { get; set; }

    }
}
