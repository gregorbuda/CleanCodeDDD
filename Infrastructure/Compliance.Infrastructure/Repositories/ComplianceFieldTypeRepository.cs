using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceFieldTypeRepository : RepositoryBase<ComplianceFieldType>, IComplianceFieldTypeRepository
    {
        public ComplianceFieldTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ComplianceFieldType>> GetItemFullDataList()
        {
            var result = await _context.ComplianceFieldType
                .Include(complianceFieldType => complianceFieldType.InputBehaviour)
                .Include(complianceFieldType => complianceFieldType.FileResourceType)
                .ToListAsync();

            return result;
        }

        public async Task<ComplianceFieldType> GetFullDataById(Int32 ComplianceFieldTypeId)
        {
            var result = await _context.ComplianceFieldType
                .Include(complianceFieldType => complianceFieldType.InputBehaviour)
                .Include(complianceFieldType => complianceFieldType.FileResourceType)
                .Where(complianceFieldType => complianceFieldType.ComplianceFieldTypeId == ComplianceFieldTypeId)
                .FirstOrDefaultAsync();
            
            return result;
        }

        public  List<ComplianceFieldType> GetComplianceFieldTypeByInputBehaviourId(Int32 InputBehaviourId)
        {
            return  _context.ComplianceFieldType!.Where(v => v.InputBehaviourId == InputBehaviourId).ToList();
        }

        public void Delete(int ComplianceFieldTypeId)
        {
            _context.ComplianceFieldType.First(x => x.ComplianceFieldTypeId == ComplianceFieldTypeId).Status = 2;

            _context.SaveChanges();
        }

    }
}
