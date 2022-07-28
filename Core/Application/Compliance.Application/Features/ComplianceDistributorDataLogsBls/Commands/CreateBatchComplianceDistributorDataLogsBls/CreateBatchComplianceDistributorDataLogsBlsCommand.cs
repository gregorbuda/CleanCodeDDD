using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls
{
    public class CreateBatchComplianceDistributorDataLogsBlsCommand
    {
        [Required]
        public String ComplianceDistributorLogMessage { get; set; }
        [Required]
        public String ComplianceDistributorLogData { get; set; }
        [Required]
        public Int32 ComplianceDistributorDataId { get; set; }
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
