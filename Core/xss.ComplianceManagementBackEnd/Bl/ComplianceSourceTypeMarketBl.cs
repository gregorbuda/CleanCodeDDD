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
    public class ComplianceSourceTypeMarketBl : ICRUData<ComplianceSourceTypeMarkets>
    {
        public int CreateAndReturnId(ComplianceSourceTypeMarkets item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(ComplianceSourceTypeMarkets item)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceSourceTypeMarkets.Add(item);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool DeleteItem(ComplianceSourceTypeMarkets item)
        {
            throw new NotImplementedException();
        }

        public ComplianceSourceTypeMarkets GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ComplianceSourceTypeMarkets GetFullDataById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ComplianceSourceTypeMarkets> ItemFullDataList()
        {
            throw new NotImplementedException();
        }

        public List<ComplianceSourceTypeMarkets> ItemList()
        {
            throw new NotImplementedException();
        }

        public bool SaveBatch(IEnumerable<ComplianceSourceTypeMarkets> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceSourceTypeMarkets.AddRange(itemList);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool UpdateItem(ComplianceSourceTypeMarkets item)
        {
            throw new NotImplementedException();
        }

        public List<ComplianceSourceTypeMarkets> GetByComplianceSourceTypeId(Int32? complianceSourceTypeId)
        {
            using var complianceDbContext = new ComplianceContext();
            return complianceDbContext.ComplianceSourceTypeMarkets
                .Include(complianceSourceType => complianceSourceType.Markets)
                .ToList()
                .FindAll(complianceSourceType => complianceSourceType.ComplianceSourceTypeId == complianceSourceTypeId);
        }

        public bool UpdateBatch(IEnumerable<ComplianceSourceTypeMarkets> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceSourceTypeMarkets.UpdateRange(itemList);
            return complianceDbContext.SaveChanges() > 0;
        }
    }
}
