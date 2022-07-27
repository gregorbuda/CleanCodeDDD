﻿using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IComplianceFieldTypeRepository : IAsyncRepository<ComplianceFieldType>
    {
        Task<IReadOnlyList<ComplianceFieldType>> GetItemFullDataList();

        Task<IReadOnlyList<ComplianceFieldType>> GetFullDataById(Int32 ComplianceFieldTypeId);
    }
}
