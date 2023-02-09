using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSisConBens.Models
{
    public class Bem
    {
        public int BemId { get; set; }
        
        [Display(Name = "Descrição do Bem")]
        [Required(ErrorMessage = "É obrigatório informar a Descrição do Bem", AllowEmptyStrings = false)]
        public string BemDescricao { get; set; }

        [Display(Name = "Data de Aquisição")]
        [Required(ErrorMessage = "É necessário especificar a Data da NF de Aquisição do Bem", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime BemDataaquisicao { get; set; }


        [Display(Name = "Valor Aquisição")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BemValoraquisicao { get; set; }

        [Display(Name = "Foto do Bem")]
        public string BemImagem { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Informe o Status do Bem", AllowEmptyStrings = false)]
        public string BemStatus { get; set; }

        [Display(Name = "Data do último Status")]
        [DataType(DataType.Date)]
        public DateTime BemDatastatus { get; set; } = DateTime.Now;

        [Display(Name = "Unidade de Alocação")]
        [Required(ErrorMessage = "Informe a Unidade em que o Bem está alocado", AllowEmptyStrings = false)]
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }


        [Display(Name = "Inventário")]
        [Required(ErrorMessage = "Informe o último Inventário do Bem", AllowEmptyStrings = false)]
        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }
   

    }
}
