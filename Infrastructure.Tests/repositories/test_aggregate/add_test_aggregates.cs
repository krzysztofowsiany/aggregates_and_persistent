namespace Infrastructure.Tests.repositories.test_aggregate
{
    using Xunit;

    public class add_test_aggregates
    {
        [Theory]
        [InlineData("872BA2ED-A8D0-401B-9205-19BFFE43D2E4", "1945A6E5-3409-4E7E-891A-AF956279D4D7", "any text", 1.1, 123)]
        [InlineData("61193105-81C7-46E7-A57A-C3D8F9DA1D90", "F1FAA36E-767B-429A-A43F-617DF236555A", "any text in aggregate", 0.011, -1)]
        [InlineData("51DE44CD-2197-4147-A7EF-3F29DDB58F9C", "28394E6B-8EC5-4756-8BD6-FAE773B6988E", null, 12.1234, 1234123)]
        public void test_exist_in_repository__when__add_to_repository(string testId, string test1Id, string test, double double1, int int1)
        {
            _fixture.add_test(testId, test1Id, test, double1, int1);

            act();

            _fixture.Assert_test_exist_in_repository();
        }

        private void act()
            => _fixture.act();

        private readonly add_test_aggregates_fixture _fixture;

        public add_test_aggregates()
        {
            _fixture = new add_test_aggregates_fixture();
        }
    }
}