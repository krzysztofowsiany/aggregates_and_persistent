namespace DDDCommons {
    using System;

    public abstract class Identity {
        public readonly Guid Value;
        protected Identity(Guid value) => Value = value;

        public override bool Equals(object obj) =>
            ReferenceEquals(null, obj) || obj.GetType() != GetType() 
            ? false 
            : ReferenceEquals(this, obj) 
                ? true 
                : Value.Equals(((Identity) obj).Value);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Identity left, Identity right) => Equals(left, right);
        public static bool operator !=(Identity left, Identity right) => !Equals(left, right);
    }

    public abstract class Identity<TIdentity> : Identity, IEquatable<TIdentity>
        where TIdentity : Identity<TIdentity> {
            protected Identity(Guid value) : base(value) { }

            public bool Equals(TIdentity other) => Equals((object) other);

            public static TIdentity New() =>
            (TIdentity) Activator.CreateInstance(typeof(TIdentity), (object) Guid.NewGuid());
        }
}