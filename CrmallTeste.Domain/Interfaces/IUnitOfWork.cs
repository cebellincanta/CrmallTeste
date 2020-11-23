using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrmallTeste.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository IPersonRepository { get; }

        Task<int> CommitAsync();
    }
}
