namespace DDDCommons.Tests.identities.identities_equals
{
    using System;
    using FluentAssertions;
    internal class identities_equals_tests_fixture
    {
        private bool _equals;
        private test_identity _left_equal_side;
        private test_identity _right_equal_side;

        internal void set_left_equal_side(Guid guid) => _left_equal_side = new test_identity(guid);
        internal void set_right_equal_side(Guid guid) => _right_equal_side = new test_identity(guid);

        internal void act()  => _equals = _left_equal_side == _right_equal_side;

        internal void Assert_identities_are_equal() => _equals.Should().BeTrue();
        internal void Assert_identities_are_different() => _equals.Should().BeFalse();
    }
}