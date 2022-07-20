using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using xss.ComplianceManagementBackEnd.Dao;
using xss.ComplianceManagementBackEnd.Entity;
using xss.ComplianceManagementBackEnd.Interface;

namespace xss.ComplianceManagementBackEnd.Bl
{
    public class ComplianceSourceTypeBl : ICRUData<ComplianceSourceTypes>
    {
        public int CreateAndReturnId(ComplianceSourceTypes item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceSourceTypes.Add(item);
            complianceContextDb.SaveChanges();
            return item.ComplianceSourceTypeId;
        }

        public bool CreateItem(ComplianceSourceTypes item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceSourceTypes.Add(item);
            return complianceContextDb.SaveChanges() > 0;
        }

        public bool DeleteItem(ComplianceSourceTypes item)
        {
            using var complianceContextDb = new ComplianceContext();
            complianceContextDb.ComplianceSourceTypes.Remove(item);
            return complianceContextDb.SaveChanges() > 0;
        }

        public ComplianceSourceTypes GetById(int id)
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceSourceTypes
                .ToList()
                .FirstOrDefault(complianceSourceType => complianceSourceType.ComplianceSourceTypeId == id);
        }

        public ComplianceSourceTypes GetFullDataById(int id)
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceSourceTypes
                .Include(complianceSourceType => complianceSourceType.ComplianceSource)
                .Include(complianceSourceType => complianceSourceType.ComplianceFieldType)
                .Include(complianceSourceType => complianceSourceType.ComplianceSourceTypeMarkets)
                .ToList()
                .FirstOrDefault(complianceSourceType => complianceSourceType.ComplianceSourceTypeId == id);

        }

        public List<ComplianceSourceTypes> ItemFullDataList()
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceSourceTypes
                  .Include(complianceSourceType => complianceSourceType.ComplianceSource)
                  .Include(compliancesourceType => compliancesourceType.ComplianceFieldType.InputBehaviour)
                  .Include(complianceSourceType => complianceSourceType.ComplianceSourceTypeMarkets)
                  .Where(complianceSourceType => complianceSourceType.Status != 2)
                .ToList();
            //.Select(complianceSouceType => new ComplianceSourceTypes
            //{
            //    ComplianceSource = complianceSouceType.ComplianceSource,
            //    ComplianceFieldType = complianceSouceType.ComplianceFieldType,
            //    ComplianceSourceTypeMarkets = complianceSouceType.ComplianceSourceTypeMarkets,
            //}
            //).ToList();
        }

        public List<ComplianceSourceTypes> ItemList()
        {
            using var complianceContextDb = new ComplianceContext();
            return complianceContextDb.ComplianceSourceTypes.ToList();
        }

        public bool SaveBatch(IEnumerable<ComplianceSourceTypes> itemList)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateBatch(IEnumerable<ComplianceSourceTypes> itemList)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceSourceTypes.UpdateRange(itemList);
            return complianceDbContext.SaveChanges() > 0;
        }

        public bool UpdateItem(ComplianceSourceTypes item)
        {
            using var complianceDbContext = new ComplianceContext();
            complianceDbContext.ComplianceSourceTypes.Update(item);
            return complianceDbContext.SaveChanges() > 0;
        }
    }
}
