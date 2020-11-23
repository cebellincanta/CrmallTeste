using CrmallTeste.AppService.Extensions;
using CrmallTeste.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmallTeste.AppService.DTO
{
    public class PersonalDTO
    {
        string _id;
        public PersonalDTO()
        {
        }

        public PersonalDTO(string id, string name, string dateOfBirth, Genre genre, string zipCode, string street, string number, string complement, string neighborhood, string city, string state, string cpf)
        {
            Id = id;
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

        public string Id {

            get
            {
                if (_id == null)
                    _id = Guid.NewGuid().ToString();

                return _id;
            }
            set { _id = value; }

        }
        [Required(ErrorMessage = "O campo nome completo é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Data Nasicmento obrigatório.")]
        public string DateOfBirth { get; set; }
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public string Number { get; set; }
        public string Complement { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string City { get; set; }
        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string State { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [Cpf(ErrorMessage = "O Cpf informado é invalido.")]
        public string Cpf { get; set; }
        
    }
}
