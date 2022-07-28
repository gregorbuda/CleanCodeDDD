using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IComplianceSourceRepository complianceSourceRepository { get; }

        IInputBehaviourRepository inputBehaviourRepository { get; }

        IFileResourceTypeRepository fileResourceTypeRepository { get; }

        IComplianceFieldTypeRepository complianceFieldTypeRepository  { get; }

        IComplianceSourceTypesRepository complianceSourceTypesRepository { get; }

        IComplianceSourceTypeMarketsRepository complianceSourceTypeMarketsRepository { get; }

        IComplianceDistributorDataRepository complianceDistributorDataRepository { get; }

        IComplianceDistributorDataLogsRepository complianceDistributorDataLogsRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class, new();
        Task<int> Complete();
    }
}
