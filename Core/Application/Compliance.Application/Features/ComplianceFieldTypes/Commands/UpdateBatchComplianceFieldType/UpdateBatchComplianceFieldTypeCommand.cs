﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType
{
    public class UpdateBatchComplianceFieldTypeCommand
    {
        [Required]
        public Int32 ComplianceFieldTypeId { get; set; }
        [Required]
        public string ComplianceFieldTypeName { get; set; } = string.Empty;
        [Required]
        public string TranslationKey { get; set; } = string.Empty;
        [Required]
        public string FieldPath { get; set; } = string.Empty;
        [Required]
        public int? ComplianceFileSizeKb { get; set; }
        [Required]
        public short? HeightPx { get; set; }
        [Required]
        public short? WidthPx { get; set; }
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [Required]
        public int InputBehaviourId { get; set; }
        [Required]
        public int FileResourceTypeId { get; set; }
    }
}
