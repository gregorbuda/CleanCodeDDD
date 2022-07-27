using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class ComplianceFieldTypeFullDataResponse
    {
        public int ComplianceFieldTypeId { get; set; }
        public string ComplianceFieldTypeName { get; set; }
        public string TranslationKey { get; set; }
        public string FieldPath { get; set; }
        public int? ComplianceFileSizeKb { get; set; }
        public short? HeightPx { get; set; }
        public short? WidthPx { get; set; }
        /// <example>Active</example>
        public EnumComplianceSourceStatus Status { get; set; }

        public InputBehaviourResponse InputBehaviour { get; set; }

        public  FileResourceTypeResponse FileResourceType { get; set; }

        public  List<ComplianceSourceTypesResponse> ComplianceSourceTypes { get; set; }
    }
}
