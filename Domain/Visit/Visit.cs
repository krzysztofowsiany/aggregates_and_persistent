namespace Domain.Visit {
    using System;
    using DDDCommons;
    public class Visit : IAggregateRoot<VisitId, Visit.VisitState>
    {
        private VisitState _state;
        public VisitState State => _state;

        public struct VisitState
        {
            public DoctorId Doctor;
            public DateTime Date;
            public PatientId Patient;
        }

        public Visit(DoctorId doctorId, DateTime date, PatientId patientId = null) {
            _state = new VisitState {
                Doctor = doctorId ?? throw new ArgumentNullException(nameof(doctorId)),
                Date = date,
                Patient = patientId
            };            
        }

        public void ReserveVisit(PatientId patientId) {
            if (_state.Patient == null) {
                _state.Patient = patientId;
            }

            if (_state.Patient == patientId) {
                return;
            }

            throw new Exception("Alredy taken");
        }
    }
}