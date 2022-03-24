using System.ComponentModel.DataAnnotations;

namespace Agencia.Models
{
    public class Ajuda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Dúvida {get; set; }

    }
}
