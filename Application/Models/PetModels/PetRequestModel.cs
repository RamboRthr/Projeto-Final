using Domain.Builder;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.PetModels
{
    public class PetRequestModel : PetAbstractModel
    {
        [Required(ErrorMessage = "O Id do Dono é um campo obrigatório")]
        public virtual int UserId { get; set; }

        public Pet ConvertToPetEntity()
        {
            return new PetBuilder()
                .SetUserId(UserId)
                .SetName(Name)
                .SetSpecie(Specie)
                .SetBreed(Breed)
                .SetAgeYears(AgeYears)
                .SetAgeMonths(AgeMonths)
                .SetSize(Size)
                .SetDescription(Description)
                .Build();
        }
    }
}
