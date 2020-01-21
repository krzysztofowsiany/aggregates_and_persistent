namespace Domain
{
    using System;
    using DDDCommons;
    public class PatientId : Identity<PatientId>
    {
        public PatientId(Guid value): base(value)    {  }

    }
}