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
    public class MockComplianceSourcesRepository
    {
        public static void AddDataInputComplianceSources(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var complianceSources = fixture.CreateMany<ComplianceSource>().ToList();

            complianceSources.Add(fixture.Build<ComplianceSource>()
                .With(tr => tr.ComplianceSourceId, 1)
                .Create()
                );

            applicationDbContextFake.ComplianceSource!.AddRange(complianceSources);
            applicationDbContextFake.SaveChanges();
        }
    }
}
