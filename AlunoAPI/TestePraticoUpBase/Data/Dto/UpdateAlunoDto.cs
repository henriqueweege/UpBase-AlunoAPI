using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    public class UpdateAlunoDto
    {
        
        public string NomeCompleto { get; set; }
        public string NomeDeUsuario { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }



    }
}
