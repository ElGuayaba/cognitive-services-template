using System;
using System.Collections;
using static System.Object;

namespace Namespace.ProjectName.Domain.Contract.Entity
{
    public abstract class AbstractEntity : IComparable<AbstractEntity>
    {
        public virtual Guid Id { get; set; }

        public int CompareTo(AbstractEntity other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Id.CompareTo(other.Id);
        }

        protected bool Equals(AbstractEntity other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbstractEntity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        
        public static bool operator ==(AbstractEntity left, AbstractEntity right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }
        public static bool operator !=(AbstractEntity left, AbstractEntity right)
        {
            return !(left == right);
        }
    }
}