using Domain.Builder;
using Domain.Entities;

namespace Application.Models.UserModels
{
    public class UserUpdateRequestModel : UserAbstractModel
    {
        public int Id { get; set; }

        public User ConvertToUserEntity()
        {
            return new UserBuilder()
                .SetId(Id)
                .SetName(Name)
                .SetSurname(Surname)
                .SetCpf(Cpf)
                .SetEmail(Email)
                .SetPhone(Phone)
                .SetStreet(Street)
                .SetHouseNumber(HouseNumber)
                .SetDistrict(District)
                .SetCep(Cep)
                .SetBirthDate(BirthDate)
                .SetPassword(Password)
                .Build();
        }
    }
}
