using Domain.Builder;
using Domain.Entities;

namespace Application.Models.UserModels
{
    public class UserRequestModel : UserAbstractModel
    {
        public User ConvertToUserEntity()
        {
            return new UserBuilder()
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
