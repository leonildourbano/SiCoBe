using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace ProjetoSisConBens.Models
{
    public class Inventario
    {
        public int InventarioId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "É obrigatório informar o Código do Inventárioem", AllowEmptyStrings = false)]
        public string InventarioDescricao { get; set; }

        
        [Display(Name = "Início")]
        [Required(ErrorMessage = "Informe a Data de Início do Inventário", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime InventarioDatainicio { get; set; }

        [Display(Name = "Término")]
        [Required(ErrorMessage = "Informe a Data de Término do Inventário", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime InventarioDatatermino { get; set; }

       
        [Display(Name = "Memória do Inventário")]
        public string InventarioMemoria { get; set; }


        public ICollection<Bem> Bem { get; set; }
    

    }
}
