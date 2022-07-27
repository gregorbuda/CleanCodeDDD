using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class InputBehaviourResponse
    {
        public int InputBehaviourId { get; set; }

        public string InputBehaviourName { get; set; } = string.Empty;
        /// <example>Active</example>
        public EnumComplianceSourceStatus Status { get; set; }

    }
}
