﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class FileResourceTypeResponse
    {
        public int FileResourceTypeId { get; set; }
        public string Name { get; set; }
        public string TranslationKey { get; set; }
        public string Description { get; set; }
        public int MaxSize { get; set; }
        /// <example>Active</example>
        public EnumComplianceSourceStatus Status { get; set; }
    }
}
