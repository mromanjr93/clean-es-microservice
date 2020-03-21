using System.Collections.Generic;

namespace Shared.Domain.Entities
{
    public abstract class Entity<TEntity, TId> : BaseEntity
        where TEntity : Entity<TEntity, TId>
    {
        #region Properties
        public virtual TId Id { get; set; }
        
        #endregion

        #region Public methods
        public static bool operator ==(Entity<TEntity, TId> left, Entity<TEntity, TId> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TEntity, TId> left, Entity<TEntity, TId> right)
        {
            return !(left == right);
        }

        public override bool IsTransient()
        {
            return EqualityComparer<TId>.Default.Equals(Id, default(TId));
        }
        #endregion

        #region Object overrides
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TEntity, TId>))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var item = (Entity<TEntity, TId>)obj;

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }

            return EqualityComparer<TId>.Default.Equals(item.Id, Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!RequestedHashCode.HasValue)
                {
                    RequestedHashCode = Id.GetHashCode() ^ 31;
                }

                return RequestedHashCode.Value;
            }

            return base.GetHashCode();
        }
        #endregion
    }
}