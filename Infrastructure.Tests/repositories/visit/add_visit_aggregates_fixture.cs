using System;
using Domain;
using Domain.Visit;
using Infrastructure.Repositories;

namespace Infrastructure.Tests.repositories.visit
{
    using FluentAssertions;
    
    public class add_visit_aggregates_fixture
    {
        private readonly VisitRepository _repository;
        private VisitId _visitId;
        private Visit _visit;
        private DoctorId _doctorId;

        public add_visit_aggregates_fixture()
        {
            _repository = new VisitRepository();
        }

        public void add_visit(string visitId, string doctorId, string date, string parentId = null)
        {
            _visitId = new VisitId(new Guid(visitId));
            _doctorId = new DoctorId(new Guid(doctorId));
            _visit = new Visit(_doctorId, DateTime.Parse(date));
        }

        public void save_and_reserve_visit(string patinetId)
        {
            _repository.Save(_visit, _visitId);
            _visit.ReserveVisit(new PatientId(new Guid(patinetId)));
        }

        public void act()
            => _repository.Save(_visit, _visitId);

        public void Assert_visit_exist_in_repository()
        {
            var visit = _repository.Get(_visitId);

            visit.State.Date.Should().Be(_visit.State.Date);
            visit.State.Doctor.Should().Be(_visit.State.Doctor);
            visit.State.Patient.Should().Be(_visit.State.Patient);
        }
    }
}