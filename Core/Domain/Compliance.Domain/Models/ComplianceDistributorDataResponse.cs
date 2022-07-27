using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class ComplianceDistributorDataResponse
    {
        public int ComplianceDistributorDataId { get; set; }
        public int ComplianceSourceTypeId { get; set; }
        public int DistributorId { get; set; }
        public string FieldData { get; set; }
        public byte Status { get; set; }
    }
}
