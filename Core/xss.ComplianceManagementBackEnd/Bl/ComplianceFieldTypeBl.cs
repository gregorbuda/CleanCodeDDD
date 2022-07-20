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
    public class ComplianceFieldTypeBl : ICRUData<ComplianceFieldType>
    {
        public int CreateAndReturnId(ComplianceFieldType item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(ComplianceFieldType item)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceFieldType.Add(item);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool DeleteItem(ComplianceFieldType item)
        {
            using var companyDbContext = new ComplianceContext();
            companyDbContext.ComplianceFieldType.Remove(item);
            return companyDbContext.SaveChanges() > 0;  
        }

        public ComplianceFieldType GetById(int id)
        {
            using var companyDbContext = new ComplianceContext();
            return companyDbContext.ComplianceFieldType
                .ToList()
                .FirstOrDefault(complianceFieldType => complianceFieldType.ComplianceFieldTypeId == id);

        }

        public ComplianceFieldType GetFullDataById(int id)
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceFieldType
                .Include(complianceFieldType => complianceFieldType.InputBehaviour)
                .Include(complianceFieldType => complianceFieldType.FileResourceType)
                .ToList()
                .FirstOrDefault(complianceFieldType => complianceFieldType.ComplianceFieldTypeId == id);
        }

        public List<ComplianceFieldType> ItemFullDataList()
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceFieldType
                .Include(complianceFieldType => complianceFieldType.InputBehaviour)
                .Include(complianceFieldType => complianceFieldType.FileResourceType)
                .ToList();
        }

        public List<ComplianceFieldType> ItemList()
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceFieldType
                .ToList();
        }

        public bool SaveBatch(IEnumerable<ComplianceFieldType> itemList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBatch(IEnumerable<ComplianceFieldType> itemList)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceFieldType.UpdateRange(itemList);
            return complianceContextDb.SaveChanges() > 0;
        }

        public bool UpdateItem(ComplianceFieldType item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceFieldType.Update(item);
            return complianceContextDb.SaveChanges() > 0;
        }
    }
}
