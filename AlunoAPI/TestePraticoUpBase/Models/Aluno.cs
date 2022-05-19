using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Models
{

    [Index(nameof(NomeDeUsuario), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]

    public class Aluno
    { 
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; }


        [Required]
        public string NomeDeUsuario { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        
        
    }
}
