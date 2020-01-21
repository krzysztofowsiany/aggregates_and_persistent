using System;
using Domain;
using Domain.Visit;
using Infrastructure.Repositories;
using Infrastructure.Tests.repositories.test_aggregate.fixture;

namespace Infrastructure.Tests.repositories.test_aggregate
{
    using FluentAssertions;
    
    public class add_test_aggregates_fixture
    {
        private readonly TestRepository _repository;
        private TestId _testId;
        private Test _test;
        private Test1Id _test1Id;

        public add_test_aggregates_fixture()
        {
            _repository = new TestRepository();
        }

        public void add_test(string testId, string test1Id, string tekst, double double1, int int1)
        {
            _testId = new TestId(new Guid(testId));
            _test1Id = new Test1Id(new Guid(test1Id));
            _test = new Test(_test1Id, tekst, int1, double1);
        }

        public void act()
            => _repository.Save(_test, _testId);

        public void Assert_test_exist_in_repository()
        {
            var test = _repository.Get(_testId);
            
            test.State.Test1.Should().Be(_test.State.Test1);
            test.State.Double1.Should().Be(_test.State.Double1);
            test.State.Int1.Should().Be(_test.State.Int1);
            test.State.Tekst1.Should().Be(_test.State.Tekst1);
        }
    }
}