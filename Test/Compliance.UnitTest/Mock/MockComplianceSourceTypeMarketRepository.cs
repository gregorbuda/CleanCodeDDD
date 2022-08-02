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
    public class MockComplianceSourceTypeMarketRepository
    {
        public static void AddDataComplianceSourceTypeMarket(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var complianceSourcesTypeMarkets = fixture.CreateMany<ComplianceSourceTypeMarkets>().ToList();

            complianceSourcesTypeMarkets.Add(fixture.Build<ComplianceSourceTypeMarkets>()
                .With(tr => tr.ComplianceSourceTypeMarketId, 7)
                .Create()
                );

            applicationDbContextFake.ComplianceSourceTypeMarkets!.AddRange(complianceSourcesTypeMarkets);
            applicationDbContextFake.SaveChanges();
        }
    }
}
