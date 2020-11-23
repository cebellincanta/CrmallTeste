using CrmallTeste.Domain.Interfaces;
using CrmallTeste.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrmallTeste.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrmallContext _context;

        private PersonalRepository _personalRepository;

        public UnitOfWork(CrmallContext context)
        {
            _context = context;
        }
        public IPersonRepository IPersonRepository => _personalRepository ??= new PersonalRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
