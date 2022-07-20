using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    public partial class FileResourceExtension
    {
        public int FileResourceExtensionId { get; set; }
        public int FileResourceTypeId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int Status { get; set; }

        public virtual FileResourceType FileResourceType { get; set; }
    }
}
