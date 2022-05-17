using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Models
{
    public class Aluno
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public string NomeDeUsuario { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        
    }
}
