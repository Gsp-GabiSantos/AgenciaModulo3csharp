using System.ComponentModel.DataAnnotations;

namespace Agencia.Models
{
    public class CadastroDestino
    {
     
        [Key]
        public int IdDestino { get; set; }
        [Required]
        public string Nome_Destino { get; set; }
        
        [Required]
        public string Lugar { get; set; }

        [Required]
        public string Valor { get; set; }
        public virtual List<Comprar> Comprar { get; set; }

       

        
    }
}
