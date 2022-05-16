using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    public class CreateAlunoDto
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
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
