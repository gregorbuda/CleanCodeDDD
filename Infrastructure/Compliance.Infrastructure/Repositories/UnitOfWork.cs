using Compliance.Application.Contracts.Persistence;
using Compliance.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ApplicationDbContext _context;

        private IComplianceFieldTypeRepository _complianceFieldTypeRepository;
        public IComplianceFieldTypeRepository complianceFieldTypeRepository => _complianceFieldTypeRepository ??
        new ComplianceFieldTypeRepository(_context);


        private IFileResourceTypeRepository _fileResourceTypeRepository;
        public IFileResourceTypeRepository fileResourceTypeRepository => _fileResourceTypeRepository ??
         new FileResourceTypeRepository(_context);

        private IComplianceSourceRepository _complianceSourceRepository;
        public IComplianceSourceRepository complianceSourceRepository => _complianceSourceRepository ??
            new ComplianceSourceRepository(_context);

        private IInputBehaviourRepository _inputBehaviourRepository;
        public IInputBehaviourRepository inputBehaviourRepository => _inputBehaviourRepository ??
            new InputBehaviourRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationDbContext applicationDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class, new()
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
