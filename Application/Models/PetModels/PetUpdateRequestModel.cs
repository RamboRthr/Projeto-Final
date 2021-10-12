using Domain.Builder;
using Domain.Entities;

namespace Application.Models.PetModels
{
    public class PetUpdateRequestModel : PetAbstractModel
    {
        public int Id { get; set; }

        public Pet ConvertToPetEntity()
        {
            return new PetBuilder()
                .SetId(Id)
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
