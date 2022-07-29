using AutoFixture;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.UnitTest.Mock
{
    public class MockFileResourceTypesRepository
    {
        public static void AddDataInputFileResourceTypes(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var fileResourceType = fixture.CreateMany<FileResourceType>().ToList();

            fileResourceType.Add(fixture.Build<FileResourceType>()
                .With(tr => tr.FileResourceTypeId, 1)
                .Create()
                );

            applicationDbContextFake.FileResourceType!.AddRange(fileResourceType);
            applicationDbContextFake.SaveChanges();
        }
    }
}
