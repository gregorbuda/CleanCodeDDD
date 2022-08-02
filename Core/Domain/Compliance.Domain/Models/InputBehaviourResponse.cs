using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Input Behaviour Response
    /// </summary>
    public class InputBehaviourResponse
    {
        /// <summary>
        /// Input Behaviour Id
        /// </summary>
        /// <value>
        /// Input Behaviour Id
        /// </value>
        /// <example>1</example>        
        public Int32 InputBehaviourId { get; set; }
        /// <summary>
        /// Input Behaviour Name
        /// </summary>
        /// <value>
        /// Input Behaviour Name
        /// </value>
        /// <example>Test Input Behaviour</example>   
        public String InputBehaviourName { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>   
        public EnumComplianceSourceStatus Status { get; set; }

    }
}
