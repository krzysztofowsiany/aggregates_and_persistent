using System;
using DDDCommons;

namespace Infrastructure.Tests.repositories.test_aggregate.fixture
{
    public class Test1Id : Identity<Test1Id>
    {
        public Test1Id(Guid value) : base(value)
        {
        }
    }
}