namespace Domain
{
    using System;
    using DDDCommons;
    public class DoctorId: Identity<DoctorId>
    {
        public DoctorId(Guid value): base(value)    {  }

    }
}