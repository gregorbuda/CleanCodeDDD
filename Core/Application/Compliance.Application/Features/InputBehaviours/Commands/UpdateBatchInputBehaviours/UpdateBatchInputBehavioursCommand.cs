using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours
{
    public  class UpdateBatchInputBehavioursCommand
    {
        [Required]
        public Int32 InputBehaviourId { get; set; }
        [Required]
        public string InputBehaviourName { get; set; } = string.Empty;
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
