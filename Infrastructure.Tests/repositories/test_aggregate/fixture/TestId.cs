using System;
using DDDCommons;

namespace Infrastructure.Tests.repositories.test_aggregate.fixture
{
    public class TestId : Identity<TestId>
    {
        public TestId(Guid value) : base(value)
        {
        }
    }
}