using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Models
{

    [Index(nameof(NomeDeUsuario), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]

    public class Aluno
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        [MaxLength(250)]

        public string NomeDeUsuario { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        
    }
}
