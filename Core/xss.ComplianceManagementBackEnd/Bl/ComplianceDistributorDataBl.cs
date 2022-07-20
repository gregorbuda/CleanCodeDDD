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
    public class ComplianceDistributorDataBl : ICRUData<ComplianceDistributorData>
    {
        public int CreateAndReturnId(ComplianceDistributorData item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(ComplianceDistributorData item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ComplianceDistributorData item)
        {
            throw new NotImplementedException();
        }

        public ComplianceDistributorData GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ComplianceDistributorData GetFullDataById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ComplianceDistributorData> ItemFullDataList()
        {
            using var complianceDbContext = new ComplianceContext();
            return complianceDbContext.ComplianceDistributorData
                .Include(complianceDistributor => complianceDistributor.ComplianceSourceType.ComplianceFieldType.InputBehaviour)
                .Include(complianceDistributor => complianceDistributor.ComplianceSourceType.ComplianceSource)
                .ToList();
        }
        public List<ComplianceDistributorData> ItemFullDataListByDistributor(int distributorId)
        {
            using var complianceDbContext = new ComplianceContext();
            return complianceDbContext.ComplianceDistributorData
                .Where(complianceDistributor => complianceDistributor.DistributorId == distributorId)
                .Include(complianceDistributor => complianceDistributor.ComplianceSourceType.ComplianceFieldType.InputBehaviour)
                .Include(complianceDistributor => complianceDistributor.ComplianceDistributorDataLogs)
                .ToList();
        }


        public List<ComplianceDistributorData> ItemList()
        {
            throw new NotImplementedException();
        }

        public bool SaveBatch(IEnumerable<ComplianceDistributorData> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceDistributorData.AddRange(itemList);
            return complianceDbContext.SaveChanges() > 0;
        }

        public List<ComplianceDistributorData> UpdateBatchAnReturn(List<ComplianceDistributorData> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceDistributorData.UpdateRange(itemList);
            complianceDbContext.SaveChanges();
            return itemList;
        }

        public bool UpdateBatch(IEnumerable<ComplianceDistributorData> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceDistributorData.UpdateRange(itemList);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool UpdateItem(ComplianceDistributorData item)
        {
            throw new NotImplementedException();
        }
    }
}
