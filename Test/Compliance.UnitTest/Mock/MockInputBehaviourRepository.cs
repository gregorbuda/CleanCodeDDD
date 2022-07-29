using AutoFixture;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using Compliance.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.UnitTest.Mock
{
    public class MockInputBehaviourRepository
    {
        public static void AddDataInputBehaviourRepository(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var inputBehaviour = fixture.CreateMany<InputBehaviour>().ToList();

            inputBehaviour.Add(fixture.Build<InputBehaviour>()
                .With(tr => tr.InputBehaviourId, 1)
                .Create()
                );

            applicationDbContextFake.InputBehaviour!.AddRange(inputBehaviour);
            applicationDbContextFake.SaveChanges();
        }
    }
}
