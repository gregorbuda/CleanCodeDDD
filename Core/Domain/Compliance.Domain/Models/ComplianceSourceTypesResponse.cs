using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class ComplianceSourceTypesResponse
    {
        public int ComplianceSourceTypeId { get; set; }
        public int ComplianceSourceId { get; set; }
        public int ComplianceFieldTypeId { get; set; }
        public int DistributorId { get; set; }
        public bool RequiresCompliance { get; set; }
        public int? ComplianceFileSizeKb { get; set; }
        public short? HeightPx { get; set; }
        public short? WidthPx { get; set; }
        /// <example>Active</example>
        public EnumComplianceSourceStatus Status { get; set; }

    }
}
