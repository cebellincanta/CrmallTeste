using CrmallTeste.Domain.Entities;
using CrmallTeste.Domain.Interfaces;
using CrmallTeste.Infra.Persistence;
using CrmallTeste.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.Infra.Repositories
{
    public class PersonalRepository : RepositoryBase<Personal>, IPersonRepository
    {
        public PersonalRepository(CrmallContext context) : base(context)
        {
        }
    }
}
