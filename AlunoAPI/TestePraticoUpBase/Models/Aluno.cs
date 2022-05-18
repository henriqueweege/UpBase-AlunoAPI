using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Models
{

    [Index(nameof(NomeDeUsuario), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]

    public class Aluno
    { 
        public int Id { get; set; }

        public string NomeCompleto { get; set; }


        public string NomeDeUsuario { get; set; }


        public string Email { get; set; }


        
        public string Password { get; set; }

        
        
    }
}
