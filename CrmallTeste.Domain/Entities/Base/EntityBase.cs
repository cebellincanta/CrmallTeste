using CrmallTeste.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            DateCreation = DateTime.Now;
            RecordSituation = RecordSituation.ACTIVE;
        }

        public string Id { get; set; }

        public DateTime DateCreation { get; set; }

        public RecordSituation RecordSituation { get; set; }
    }
}
