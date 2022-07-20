using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace xss.ComplianceManagementBackEnd.Entity
{
    public partial class FileResourceType
    {
        public FileResourceType()
        {
            FileResourceExtension = new HashSet<FileResourceExtension>();
        }

        public int FileResourceTypeId { get; set; }
        public string Name { get; set; }
        public string TranslationKey { get; set; }
        public string Description { get; set; }
        public int MaxSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ComplianceFieldType> ComplianceFieldTypes { get; set; }
        public virtual ICollection<FileResourceExtension> FileResourceExtension { get; set; }
    }
}
