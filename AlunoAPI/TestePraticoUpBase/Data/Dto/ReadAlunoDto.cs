using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    public class ReadAlunoDto
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string NomeCompleto { get; set; }

        [MaxLength(250)]
        public string NomeDeUsuario { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

    }
}
