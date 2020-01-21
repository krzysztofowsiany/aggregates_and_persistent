using Domain;
using Domain.Visit;
using LiteDB;

namespace Infrastructure.Repositories
{
    public class VisitRepository : RepositoryBase
    {
        public VisitRepository() : base()
        {
            RegisterType<DoctorId>();
            RegisterType<PatientId>();
        }

        public Visit Get(VisitId visitId)
            => Get<Visit, Visit.VisitState>(visitId.Value,
                state => new Visit(
                    state.Doctor, 
                    state.Date, 
                    state.Patient)
            );

        public void Save(Visit visit, VisitId visitId)
            => Save(visit.State, visitId.Value);
    }
}