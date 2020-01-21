namespace Infrastructure.Tests.repositories.visit
{
    using Xunit;

    public class add_visit_aggregates
    {
        [Theory]
        [InlineData("872BA2ED-A8D0-401B-9205-19BFFE43D2E4", "1945A6E5-3409-4E7E-891A-AF956279D4D7", "2019-01-01")]
        [InlineData("61193105-81C7-46E7-A57A-C3D8F9DA1D90", "F1FAA36E-767B-429A-A43F-617DF236555A", "2020-01-01 01:01:00")]
        [InlineData("51DE44CD-2197-4147-A7EF-3F29DDB58F9C", "28394E6B-8EC5-4756-8BD6-FAE773B6988E", "2019-11-01 10:11:22")]
        public void visit_exist_in_repository__when__add_to_repository_without_patient(string visitId, string doctorId, string date)
        {
            _fixture.add_visit(visitId, doctorId, date);

            act();

            _fixture.Assert_visit_exist_in_repository();
        }
        
        [Theory]
        [InlineData("872BA2ED-A8D0-401B-9205-19BFFE43D2E4", "1945A6E5-3409-4E7E-891A-AF956279D4D7", "1945A6E5-3409-4E7E-891A-AF956279D4D7", "2019-01-01")]
        [InlineData("61193105-81C7-46E7-A57A-C3D8F9DA1D90", "F1FAA36E-767B-429A-A43F-617DF236555A","F1FAA36E-767B-429A-A43F-617DF236555A", "2020-01-01 01:01:00")]
        [InlineData("51DE44CD-2197-4147-A7EF-3F29DDB58F9C", "28394E6B-8EC5-4756-8BD6-FAE773B6988E", "28394E6B-8EC5-4756-8BD6-FAE773B6988E", "2019-11-01 10:11:22")]
        public void visit_exist_in_repository__when__add_to_repository_with_patient(string visitId, string doctorId, string patientId, string date)
        {
            _fixture.add_visit(visitId, doctorId, date, patientId);
            
            act();

            _fixture.Assert_visit_exist_in_repository();
        }
        
        [Theory]
        [InlineData("872BA2ED-A8D0-401B-9205-19BFFE43D2E4", "1945A6E5-3409-4E7E-891A-AF956279D4D7", "1945A6E5-3409-4E7E-891A-AF956279D4D7", "2019-01-01")]
        [InlineData("61193105-81C7-46E7-A57A-C3D8F9DA1D90", "F1FAA36E-767B-429A-A43F-617DF236555A","F1FAA36E-767B-429A-A43F-617DF236555A", "2020-01-01 01:01:00")]
        [InlineData("51DE44CD-2197-4147-A7EF-3F29DDB58F9C", "28394E6B-8EC5-4756-8BD6-FAE773B6988E", "28394E6B-8EC5-4756-8BD6-FAE773B6988E", "2019-11-01 10:11:22")]
        public void reserve_visit_exist_in_repository__when__add_to_repository_and_reserve_patient(string visitId, string doctorId, string patientId, string date)
        {
            _fixture.add_visit(visitId, doctorId, date);
            _fixture.save_and_reserve_visit(patientId);
            
            act();

            _fixture.Assert_visit_exist_in_repository();
        }

        private void act()
            => _fixture.act();

        private readonly add_visit_aggregates_fixture _fixture;

        public add_visit_aggregates()
        {
            _fixture = new add_visit_aggregates_fixture();
        }
    }
}