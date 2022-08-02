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
    public class MockComplianceDistributorDataLogsBlsRepository
    {
        public static void AddDataInputComplianceDistributorsDataLogsBls(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var complianceDistributorDataLogsBls = fixture.CreateMany<ComplianceDistributorDataLogs>().ToList();

            complianceDistributorDataLogsBls.Add(fixture.Build<ComplianceDistributorDataLogs>()
                .With(tr => tr.ComplianceDistributorLogId, 1)
                .Create()
                );

            applicationDbContextFake.ComplianceDistributorDataLogs!.AddRange(complianceDistributorDataLogsBls);
            applicationDbContextFake.SaveChanges();
        }
    }
}
