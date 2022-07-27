﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class ComplianceFieldTypeResponse
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
    }
}
