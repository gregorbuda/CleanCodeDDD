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
    public class MockComplianceFieldTypesRepository
    {
        public static void AddDataInputComplianceFieldTypes(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var complianceFieldType = fixture.CreateMany<ComplianceFieldType>().ToList();

            complianceFieldType.Add(fixture.Build<ComplianceFieldType>()
                .With(tr => tr.ComplianceFieldTypeId, 1)
                .Create()
                );

            applicationDbContextFake.ComplianceFieldType!.AddRange(complianceFieldType);
            applicationDbContextFake.SaveChanges();
        }
    }
}
