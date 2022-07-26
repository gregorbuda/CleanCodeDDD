using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Enum Status Compliance
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumComplianceSourceStatus
    {
        /// <summary>
        /// The disabled
        /// </summary>
        Disabled = 2,
        /// <summary>
        /// The active
        /// </summary>
        Active = 1,
        /// <summary>
        /// The inactive
        /// </summary>
        Inactive = 0
    }
}
