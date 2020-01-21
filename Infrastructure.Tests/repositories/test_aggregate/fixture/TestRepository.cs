using Infrastructure.Repositories;

namespace Infrastructure.Tests.repositories.test_aggregate.fixture
{
    public class TestRepository : RepositoryBase
    {
        public TestRepository() : base()
        {
            RegisterType<Test1Id>();
        }

        public Test Get(TestId testId)
            => Get<Test, Test.TestState>(testId.Value,
                state => new Test(
                    state.Test1,
                    state.Tekst1,
                    state.Int1,
                    state.Double1)
                );

        public void Save(Test test, TestId testId)
            => Save(test.State, testId.Value);
    }
}