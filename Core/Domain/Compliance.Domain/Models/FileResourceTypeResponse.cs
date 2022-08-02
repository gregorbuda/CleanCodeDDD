using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class FileResourceTypeResponse
    {
        public Int32 FileResourceTypeId { get; set; }
        public String Name { get; set; }
        public String TranslationKey { get; set; }
        public String Description { get; set; }
        public Int16 MaxSize { get; set; }
        /// <example>Active</example>
        public EnumComplianceSourceStatus Status { get; set; }
    }
}
