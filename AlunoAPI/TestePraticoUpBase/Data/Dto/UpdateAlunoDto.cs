using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    ///<sumary>
    ///Used to update a students information.
    /// </sumary>
    public class UpdateAlunoDto
    {
        ///<sumary>
        ///Name, middle name, and last name of the student.
        /// </sumary>
        /// <example>João Pereira da Silva</example>
        [MaxLength(250)]
        [Required]
        public string NomeCompleto { get; set; }


        ///<sumary>
        ///Username: name to be used in the system, must be all lowercase letters, numbers 
        ///and special characters are not allowed.
        /// </sumary>
        /// <example>joaopereiradasilva</example>
        [MaxLength(250)]
        [Required]
        [RegularExpression(@"^(?=.*[a-z]).{2,}$")]
        public string NomeDeUsuario { get; set; }



        ///<sumary>
        ///Email: must follow the email format.
        /// </sumary>
        /// <example>email@email.com.br</example>
        [MaxLength(250)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        ///<sumary>
        ///Password: must contain at least 6 characters; at least one capital letter, one special character, and one number.
        /// </sumary>
        /// <example>Senha123!</example>
        [MaxLength(250)]
        [Required]
        [RegularExpression(@"^(?=.*[A-Z]+)(?=.*[\W]+)(?=.*\d+)(?=.*[\w]).{6,}$")]
        public string Password { get; set; }



    }
}
