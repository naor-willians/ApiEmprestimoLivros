using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }

        [Required]
        public string Recebedor { get; set; }

        [Required]
        public string Fornecedor { get; set; }

        [Required]
        public string LivroEmprestado { get; set; }

        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
    }
}
