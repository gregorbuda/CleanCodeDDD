using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateBatchComplianceSourceTypeMarket
{
    public class CreateBatchComplianceSourceTypeMarketCommand
    {
        [Required]
        public int ComplianceSourceTypeId { get; set; }
        [Required]
        public int MarketId { get; set; }
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
