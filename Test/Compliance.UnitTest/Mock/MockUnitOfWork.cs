using Compliance.Infrastructure.Persistence;
using Compliance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;

namespace Compliance.UnitTest.Mock
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();

            var optiones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ApplicationDbContext")
                .Options;

            var applicationDbContextFake = new ApplicationDbContext(optiones);

            applicationDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(applicationDbContextFake);

            return mockUnitOfWork;
        }
    }
}
