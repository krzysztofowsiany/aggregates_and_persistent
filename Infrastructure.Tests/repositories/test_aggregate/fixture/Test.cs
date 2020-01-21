using DDDCommons;

namespace Infrastructure.Tests.repositories.test_aggregate.fixture
{    
    public class Test : IAggregateRoot<TestId, Test.TestState>
    {
        private TestState _state;
        
        public TestState State => _state;
        
        public struct TestState
        {
            public Test1Id Test1;
            public string Text1;
            public int Int1;
            public double Double1;
        }

        public Test(Test1Id test1Id, string text1, int int1, double double1)
            => _state = new TestState
            {
                Double1 = double1,
                Int1 = int1,
                Text1 = text1,
                Test1 = test1Id
            };
    }
}