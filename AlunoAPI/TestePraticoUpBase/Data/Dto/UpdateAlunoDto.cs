using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    public class UpdateAlunoDto
    {
        
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }


    }
}
