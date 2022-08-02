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
    public class MockComplianceDistributorsDataRepository
    {
        public static void AddDataInputComplianceDistributorsData(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var complianceDistributorData = fixture.CreateMany<ComplianceDistributorData>().ToList();

            complianceDistributorData.Add(fixture.Build<ComplianceDistributorData>()
                .With(tr => tr.ComplianceDistributorDataId, 6)
                .Create()
                );

            applicationDbContextFake.ComplianceDistributorData!.AddRange(complianceDistributorData);
            applicationDbContextFake.SaveChanges();
        }
    }
}
