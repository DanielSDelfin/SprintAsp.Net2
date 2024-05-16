using System.ComponentModel.DataAnnotations;

namespace Sprint2.Models
{
    public class ComportamentoNegocios
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long InteracoesPlataforma { get; set; }
        [Required]
        public long FrequenciaUso { get; set; }
        [Required]
        public string Feedback { get; set; }
        [Required]
        public string UsoRecursosEspecificos { get; set; }
    }
}
