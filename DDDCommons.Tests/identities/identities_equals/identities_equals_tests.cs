namespace DDDCommons.Tests.identities.identities_equals {
    using System;
    using Xunit;
    public class identities_equals_tests {

        [Fact]
        public void identities_are_equal__when__guid_are_equals_and_set() {
            var guid = Guid.NewGuid();
            _fixture.set_left_equal_side(guid);
            _fixture.set_right_equal_side(guid);

            act();

            _fixture.Assert_identities_are_equal();
        }

         [Fact]
        public void identities_are_equal__when__sides_are_null() {
            act();

            _fixture.Assert_identities_are_equal();
        }

        [Fact]
        public void identities_are_different__when__guid_are_different() {
            _fixture.set_left_equal_side(Guid.NewGuid());
            _fixture.set_right_equal_side(Guid.NewGuid());

            act();

            _fixture.Assert_identities_are_different();
        }

        [Fact]
        public void identities_are_different__when__left_side_not_set() {
            _fixture.set_right_equal_side(Guid.NewGuid());

            act();

            _fixture.Assert_identities_are_different();
        }

        [Fact]
        public void identities_are_different__when__right_side_not_set() {
            _fixture.set_left_equal_side(Guid.NewGuid());

            act();

            _fixture.Assert_identities_are_different();
        }

        private void act()
            => _fixture.act();
        private identities_equals_tests_fixture _fixture;

        public identities_equals_tests() =>
            _fixture = new identities_equals_tests_fixture();
    }
}