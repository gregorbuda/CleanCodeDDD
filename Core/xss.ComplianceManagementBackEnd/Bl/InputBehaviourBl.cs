using System;
using System.Collections.Generic;
using System.Linq;
using xss.ComplianceManagementBackEnd.Dao;
using xss.ComplianceManagementBackEnd.Entity;
using xss.ComplianceManagementBackEnd.Interface;

namespace xss.ComplianceManagementBackEnd.Bl
{
    public class InputBehaviourBl : ICRUData<InputBehaviour>
    {
        public int CreateAndReturnId(InputBehaviour item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItem(InputBehaviour item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.InputBehaviour.Add(item);
            return complianceContextDb.SaveChanges() > 0;
        }

        public bool DeleteItem(InputBehaviour item)
        {
            using var complianceContextDb = new ComplianceContext(); 
            complianceContextDb.InputBehaviour.Remove(item);
            return complianceContextDb.SaveChanges() > 0;
        }

        public InputBehaviour GetById(int id)
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.InputBehaviour
                .ToList()
                .FirstOrDefault(inputBehaviour => inputBehaviour.InputBehaviourId == id);
        }

        public InputBehaviour GetFullDataById(int id)
        {
            throw new NotImplementedException();
        }

        public List<InputBehaviour> ItemFullDataList()
        {
            throw new NotImplementedException();
        }

        public List<InputBehaviour> ItemList()
        {
            using var companyContextDb = new ComplianceContext();
            return companyContextDb.InputBehaviour
                .ToList();
        }

        public bool SaveBatch(IEnumerable<InputBehaviour> itemList)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBatch(IEnumerable<InputBehaviour> itemList)
        {
            using var companyContextDb = new ComplianceContext();
            companyContextDb.InputBehaviour.UpdateRange(itemList);
            return companyContextDb.SaveChanges() > 0;
        }

        public bool UpdateItem(InputBehaviour item)
        {
            using var companyContextDb = new ComplianceContext();
            companyContextDb.InputBehaviour.Update(item);
            return companyContextDb.SaveChanges() > 0;
        }
    }
}
