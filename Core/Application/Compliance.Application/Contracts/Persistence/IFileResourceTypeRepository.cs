﻿using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IFileResourceTypeRepository : IAsyncRepository<FileResourceType>
    {
        void Delete(Int32 FileResourceTypeId);
    }
}
