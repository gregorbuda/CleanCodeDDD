using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xss.ComplianceManagementBackEnd.Dao;
using xss.ComplianceManagementBackEnd.Entity;
using xss.ComplianceManagementBackEnd.Interface;

namespace xss.ComplianceManagementBackEnd.Bl
{
    public class FileResourceTypeBl : ICRUData<FileResourceType>
    {
        public int CreateAndReturnId(FileResourceType item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(FileResourceType item)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.FileResourceType.Add(item);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool DeleteItem(FileResourceType item)
        {
            using var companyDbContext = new ComplianceContext();
            companyDbContext.FileResourceType.Remove(item);
            return companyDbContext.SaveChanges() > 0;
        }

        public FileResourceType GetById(int id)
        {
            using var complianceDbContext = new ComplianceContext();
            return complianceDbContext.FileResourceType
                .ToList()
                .FirstOrDefault(fileResourceType => fileResourceType.FileResourceTypeId == id);
        }

        public FileResourceType GetFullDataById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FileResourceType> ItemFullDataList()
        {
            throw new NotImplementedException();
        }

        public List<FileResourceType> ItemList()
        {
            using var complianceDbContext = new ComplianceContext();
            return complianceDbContext.FileResourceType.ToList();
        }

        public bool SaveBatch(IEnumerable<FileResourceType> itemList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBatch(IEnumerable<FileResourceType> itemList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(FileResourceType item)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.FileResourceType.Update(item);
            return complianceDbContext.SaveChanges() > 0;
        }
    }
}
