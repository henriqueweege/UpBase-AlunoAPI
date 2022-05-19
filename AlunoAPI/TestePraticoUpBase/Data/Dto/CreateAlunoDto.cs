using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlunoAPI.Data.Dto
{
    ///<sumary>
    ///Used to create a new student.
    /// </sumary>
    public class CreateAlunoDto
    {
        ///<sumary>
        ///Students Id: must be setted as 0 to be generated automatically.
        /// </sumary>
        /// <example>0</example>
        [Key]
        [Required]
        public int Id { get; set; }




        ///<sumary>
        ///Name, middle name, and last name of the student.
        /// </sumary>
        /// <example>João Pereira da Silva</example>
        [Required]
        [MaxLength(250)]
        public string NomeCompleto { get; set; }


        ///<sumary>
        ///Username: name to be used in the system, must be all lowercase letters, numbers 
        ///and special characters are not allowed.
        /// </sumary>
        /// <example>joaopereiradasilva</example>
        [Required]
        [MaxLength(250)]
        [RegularExpression(@"^(?=.*[a-z]).{2,}$")]
        public string NomeDeUsuario { get; set; }




        ///<sumary>
        ///Email: must follow the email format.
        /// </sumary>
        /// <example>email@email.com.br</example>
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }




        ///<sumary>
        ///Password: must contain at least 6 characters; at least one capital letter, one special character, and one number.
        /// </sumary>
        /// <example>Senha123!</example>
        [Required]
        [MaxLength(250)]
        [RegularExpression(@"^(?=.*[A-Z]+)(?=.*[\W]+)(?=.*\d+)(?=.*[\w]).{6,}$")]
        public string Password { get; set; }

    }
}
