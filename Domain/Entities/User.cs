using Domain.Builder;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Cpf { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public string Street { get; protected set; }
        public string HouseNumber { get; protected set; }
        public string District { get; protected set; }
        public string Cep { get; protected set; }
        public string BirthDate { get; protected set; }
        public string Password { get; protected set; }
        public List<Pet> Pets { get; protected set; }

        public static User Creator(UserBuilder userBuilder)
        {
            return new User
            {
                Id = userBuilder.Id,
                Name = userBuilder.Name,
                Surname = userBuilder.Surname,
                Cpf = userBuilder.Cpf,
                Email = userBuilder.Email,
                Phone = userBuilder.Phone,
                Street = userBuilder.Street,
                HouseNumber = userBuilder.HouseNumber,
                District = userBuilder.District,
                Cep = userBuilder.Cep,
                BirthDate = userBuilder.BirthDate,
                Password = userBuilder.Password,
                CreatedAt = DateTime.Now
            };
        }
        public void UpdateUser(User updatedUser)
        {
            Name = updatedUser.Name;
            Surname = updatedUser.Surname;
            Cpf = updatedUser.Cpf;
            Email = updatedUser.Email;
            Phone = updatedUser.Phone;
            Street = updatedUser.Street;
            HouseNumber = updatedUser.HouseNumber;
            District = updatedUser.District;
            Cep = updatedUser.Cep;
            BirthDate = updatedUser.BirthDate;
            Password = updatedUser.Password;
            UpdatedAt = DateTime.Now;
        }
    }
}
