using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmallTeste.Domain.Enum
{
    public enum RecordSituation
    {
        [Display(Name = "Ativo")]
        ACTIVE,
        [Display(Name = "Inativo")]
        INACTIVE
    }

    public enum Genre
    {
        [Display(Name = "Masculino")]
        MALE,
        [Display(Name = "Feminino")]
        FEMININE
    }
}
