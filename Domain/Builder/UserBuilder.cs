using Domain.Entities;
using System;

namespace Domain.Builder
{
    public class UserBuilder
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Street { get; private set; }
        public string HouseNumber { get; private set; }
        public string District { get; private set; }
        public string Cep { get; private set; }
        public string BirthDate { get; private set; }
        public string Password { get; private set; }

        public UserBuilder SetId(int id)
        {
            this.Id = id;
            return this;
        }
        public UserBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }
        public UserBuilder SetSurname(string surname)
        {
            this.Surname = surname;
            return this;
        }
        public UserBuilder SetCpf(string cpf)
        {
            this.Cpf = cpf;
            return this;
        }
        public UserBuilder SetEmail(string email)
        {
            this.Email = email;
            return this;
        }
        public UserBuilder SetPhone(string phone)
        {
            this.Phone = phone;
            return this;
        }
        public UserBuilder SetStreet(string street)
        {
            this.Street = street;
            return this;
        }
        public UserBuilder SetHouseNumber(string houseNumber)
        {
            this.HouseNumber = houseNumber;
            return this;
        }
        public UserBuilder SetDistrict(string district)
        {
            this.District = district;
            return this;
        }
        public UserBuilder SetCep(string cep)
        {
            this.Cep = cep;
            return this;
        }
        public UserBuilder SetBirthDate(string birthDate)
        {
            this.BirthDate = birthDate;
            return this;
        }
        public UserBuilder SetPassword(string password)
        {
            this.Password = password;
            return this;
        }
        public User Build()
        {
            return User.Creator(this);
        }
    }
}
