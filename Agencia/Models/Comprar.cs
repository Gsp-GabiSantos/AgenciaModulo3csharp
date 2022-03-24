using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agencia.Models
{
    public class Comprar
    {
      
        [Key]
        public int IdCompra { get; set; }

        [Required]
        public string Seu_Nome { get; set; }

        [Required]

        public string Telefone { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Pagamento { get; set; }

        [ForeignKey("CadastroDestino")]
        public int IdDestino { get; set; }
        public virtual CadastroDestino CadastroDestino {get; set;}
       
       
        
    }
}
