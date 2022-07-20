using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xss.ComplianceManagementBackEnd.Dao;
using xss.ComplianceManagementBackEnd.Entity;
using xss.ComplianceManagementBackEnd.Interface;

namespace xss.ComplianceManagementBackEnd.Bl
{
    public class ComplianceDistributorDataLogsBl : ICRUData<ComplianceDistributorDataLogs>
    {
        public int CreateAndReturnId(ComplianceDistributorDataLogs item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(ComplianceDistributorDataLogs item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ComplianceDistributorDataLogs item)
        {
            throw new NotImplementedException();
        }

        public ComplianceDistributorDataLogs GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ComplianceDistributorDataLogs GetFullDataById(int id)
        {
            throw new NotImplementedException();
        }
        public List<ComplianceDistributorDataLogs> ItemFullDataListByDistributorId(int complianceDistributorDataId)
        {
            using var complianceDbContext = new ComplianceContext();
            return complianceDbContext
                .ComplianceDistributorDataLogs
                .Include(log => log.ComplianceDistributorData)
                .Where(log => log.ComplianceDistributorDataId == complianceDistributorDataId)
                .ToList();
        }

        public List<ComplianceDistributorDataLogs> ItemFullDataList()
        {
            throw new NotImplementedException();
        }

        public List<ComplianceDistributorDataLogs> ItemList()
        {
            throw new NotImplementedException();
        }

        public bool SaveBatch(IEnumerable<ComplianceDistributorDataLogs> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceDistributorDataLogs.AddRange(itemList);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool UpdateBatch(IEnumerable<ComplianceDistributorDataLogs> itemList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(ComplianceDistributorDataLogs item)
        {
            throw new NotImplementedException();
        }
    }
}
