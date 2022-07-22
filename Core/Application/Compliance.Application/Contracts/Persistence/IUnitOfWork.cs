using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IComplianceSourceRepository complianceSourceRepository { get; }

        IInputBehaviourRepository inputBehaviourRepository { get; }

        IFileResourceTypeRepository fileResourceTypeRepository { get; }

        IComplianceFieldTypeRepository complianceFieldTypeRepository  { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class, new();
        Task<int> Complete();
    }
}
