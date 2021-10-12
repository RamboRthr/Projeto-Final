using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.UserModels
{
    public class UserAbstractModel
    {
        [Required(ErrorMessage = "O Nome do Usuário é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário  deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Sobrenome do Usuário é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O Sobrenome do Usuário deve ter no máximo {1} caracteres.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "O Cpf do Usuário é um campo obrigatório")]
        [StringLength(11, ErrorMessage = "O Cpf do Usuário deve ter no máximo {1} caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Email do Usuário é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Telefone do Usuário é um campo obrigatório")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "A do Usuário é um campo obrigatório")]
        [StringLength(50, ErrorMessage = " A Rua do Usuário deve ter no máximo {1} caracteres.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O Número da Casa do Usuário é um campo obrigatório")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "O Bairro do Usuário é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O Bairro do Usuário deve ter no máximo {1} caracteres.")]
        public string District { get; set; }

        [Required(ErrorMessage = "O Cep do Usuário é um campo obrigatório")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "a Data de Nasc. do Usuário é um campo obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "A Senha é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "A Senha deve ter no máximo {1} caracteres.")]
        public string Password { get; set; }
    }
}
