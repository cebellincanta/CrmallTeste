using CrmallTeste.Domain.Entities.Base;
using CrmallTeste.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.Domain.Entities
{
    public class Personal : EntityBase
    {
        public Personal()
        {
        }

        public Personal(string name, string dateOfBirth, Genre genre, string zipCode, string street, string number, string complement, string neighborhood, string city, string state, string cpf)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Genre = genre;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Cpf = cpf;
        }

        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public Genre Genre { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cpf { get; set; }

    }
}
