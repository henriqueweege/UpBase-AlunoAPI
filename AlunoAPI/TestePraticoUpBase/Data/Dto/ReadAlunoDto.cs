using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    public class ReadAlunoDto
    {
        [Key]
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Email { get; set; }

    }
}
