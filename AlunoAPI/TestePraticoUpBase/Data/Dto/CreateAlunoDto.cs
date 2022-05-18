using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    public class CreateAlunoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string NomeCompleto { get; set; }

        [Required]
        [MaxLength(250)]
        public string NomeDeUsuario { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        //[DataType(DataType.Password)]
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

    }
}
