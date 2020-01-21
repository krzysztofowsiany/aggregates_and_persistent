using System;
using Domain;
using Domain.Visit;
using Infrastructure.Repositories;

namespace TestDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            var visitId = VisitId.New();
            var agg = new Visit(DoctorId.New(), DateTime.Now);

            var rep = new VisitRepository();
            var exists = rep.Get(new VisitId(Guid.Parse("b1e81cb1-0683-473a-94b6-666d9c1babe8")));
            
            rep.Save(agg, visitId);

            var vis = rep.Get(visitId);
            vis.ReserveVisit(PatientId.New());
            rep.Save(vis, visitId);
            Console.WriteLine("Hello World!");
        }
    }
}
