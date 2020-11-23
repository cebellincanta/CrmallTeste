using CrmallTeste.AppService.Validade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmallTeste.AppService.Extensions
{
    public class Cpf : ValidationAttribute
    {
        public Cpf() { }

        public override bool IsValid(object value)
        {
            return CpfCnpjValidate.Validar(value.ToString());
        }
    }
}
