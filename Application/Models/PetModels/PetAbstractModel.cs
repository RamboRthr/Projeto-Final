using System.ComponentModel.DataAnnotations;

namespace Application.Models.PetModels
{
    public class PetAbstractModel
    {
        [Required(ErrorMessage = "Nome do Pet é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O Nome do Pet deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Id do Dono é um campo obrigatório")]
        public virtual int UserId { get; set; }

        [Required(ErrorMessage = "A Especie do Pet é um campo obrigatório")]
        [StringLength(30, ErrorMessage = "A Especie do Pet deve ter no máximo {1} caracteres.")]
        public string Specie { get; set; }

        [Required(ErrorMessage = "A Raça do Pet é um campo obrigatório")]
        [StringLength(30, ErrorMessage = "A Raça do Pet deve ter no máximo {1} caracteres.")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "A Idade do Pet (Anos) é um campo obrigatório")]
        public string AgeYears { get; set; }

        [Required(ErrorMessage = "A Idade do Pet (Meses) é um campo obrigatório")]
        public string AgeMonths { get; set; }

        [Required(ErrorMessage = "O Porte do Pet é um campo obrigatório")]
        [StringLength(30, ErrorMessage = "O Porte do Pet deve ter no máximo {1} caracteres.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "A Descrição do Pet é um campo obrigatório")]
        [StringLength(300, ErrorMessage = "A Descrição do Pet deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }
    }
}
