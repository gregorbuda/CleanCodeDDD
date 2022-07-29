using Compliance.Infrastructure.Persistence;
using Compliance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.UnitTest.Mock
{
    public class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();

            var optiones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-{dbContextId}")
                .Options;

            var applicationDbContextFake = new ApplicationDbContext(optiones);

            applicationDbContextFake.ChangeTracker.Clear();

            applicationDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(applicationDbContextFake);

            return mockUnitOfWork;
        }
    }
}
