using System;
using System.Collections.Generic;
using System.Linq;
using xss.ComplianceManagementBackEnd.Dao;
using xss.ComplianceManagementBackEnd.Entity;
using xss.ComplianceManagementBackEnd.Interface;

namespace xss.ComplianceManagementBackEnd.Bl
{
    public class ComplianceSourceBl : ICRUData<ComplianceSource>
    {
        public int CreateAndReturnId(ComplianceSource item)
        {
            throw new NotImplementedException();
        }

        public Boolean CreateItem(ComplianceSource item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceSource.Add(item);
            return complianceContextDb.SaveChanges() > 0;
        }

        public Boolean DeleteItem(ComplianceSource item)
        {
            using var companyContextDb = new ComplianceContext();
            companyContextDb.ComplianceSource.Remove(item);
            return companyContextDb.SaveChanges() > 0; 
        }

		public ComplianceSource GetById(int id)
		{
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceSource.ToList()
                .Find(complianceSource => complianceSource.ComplianceSourceId == id);
        }

        public ComplianceSource GetFullDataById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ComplianceSource> ItemFullDataList()
        {
            throw new NotImplementedException();
        }

        public List<ComplianceSource> ItemList()
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceSource
                .ToList();
        }

        public bool SaveBatch(IEnumerable<ComplianceSource> itemList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBatch(IEnumerable<ComplianceSource> itemList)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceSource.UpdateRange(itemList);
            return complianceContextDb.SaveChanges() > 0;
        }

        public Boolean UpdateItem(ComplianceSource item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceSource.Update(item);
            return complianceContextDb.SaveChanges() > 0;
        }
    }
}
