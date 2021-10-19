using Domain.Builder;
using Domain.Entities;

namespace Application.Models.PetModels
{
    public class PetRequestModel : PetAbstractModel
    {
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
