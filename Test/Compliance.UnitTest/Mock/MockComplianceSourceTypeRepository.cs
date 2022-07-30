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
    public class MockComplianceSourceTypeRepository
    {
        public static void AddDataInputComplianceSourceType(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var complianceSourceTypes = fixture.CreateMany<ComplianceSourceTypes>().ToList();

            complianceSourceTypes.Add(fixture.Build<ComplianceSourceTypes>()
                .With(tr => tr.ComplianceSourceTypeId, 1)
                .Create()
                );

            applicationDbContextFake.ComplianceSourceTypes!.AddRange(complianceSourceTypes);
            applicationDbContextFake.SaveChanges();
        }
    }
}
