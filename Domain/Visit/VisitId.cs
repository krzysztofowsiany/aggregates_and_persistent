namespace Domain.Visit
{
    using System;
    using DDDCommons;
    public class VisitId: Identity<VisitId>
    {
        public VisitId(Guid value): base(value)    {  }
    }
}