using System;

namespace Namespace.ProjectName.Domain.Entity
{
    public abstract class BaseEntity : IComparable<BaseEntity>
    {
        public virtual Guid Id { get; set; }

        public int CompareTo(BaseEntity other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Id.CompareTo(other.Id);
        }

        protected bool Equals(BaseEntity other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseEntity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }
        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
    }
}