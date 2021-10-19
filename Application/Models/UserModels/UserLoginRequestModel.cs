using System.ComponentModel.DataAnnotations;

namespace Application.Models.UserModels
{
    public class UserLoginRequestModel
    {
        [Required(ErrorMessage = "O Email do Usuário é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "A Senha deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }
    }
}
