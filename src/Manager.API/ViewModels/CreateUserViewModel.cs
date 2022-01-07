using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        [MaxLength(120, ErrorMessage = "O nome deve ter no máximo 120 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser nulo")]
        [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O nome deve ter no máximo 180 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",  ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser nula")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        [MaxLength(20, ErrorMessage = "A senha deve ter no máximo 20 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser nulo")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve possuir 11 dígitos")]
        [RegularExpression(@"^\d{11}", ErrorMessage = "O formato do CPF é inválido")]
        public string Cpf { get; set; }

    }
}