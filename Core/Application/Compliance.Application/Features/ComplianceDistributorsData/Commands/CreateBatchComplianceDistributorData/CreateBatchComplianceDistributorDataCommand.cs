using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData
{
    public class CreateBatchComplianceDistributorDataCommand
    {
        [Required]
        public Int32 ComplianceSourceTypeId { get; set; }
        [Required]
        public Int32 DistributorId { get; set; }
        [Required]
        public String FieldData { get; set; }
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
