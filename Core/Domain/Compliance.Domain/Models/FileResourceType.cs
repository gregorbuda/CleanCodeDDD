using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    public partial class FileResourceType
    {
        public FileResourceType()
        {
            FileResourceExtension = new HashSet<FileResourceExtension>();
        }

        public Int32 FileResourceTypeId { get; set; }
        public String Name { get; set; }
        public String TranslationKey { get; set; }
        public String Description { get; set; }
        public Int32 MaxSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ComplianceFieldType> ComplianceFieldTypes { get; set; }
        public virtual ICollection<FileResourceExtension> FileResourceExtension { get; set; }
    }
}
