using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;

namespace Shared.Domain.Entities
{
    public abstract class BaseEntity : Notifiable
    {
       

        protected virtual int? RequestedHashCode { get; set; }

        public virtual long? Version { get; set; }

        #region Operators
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
        #endregion

        #region Public methods
        public abstract bool IsTransient();

        public abstract void ValidateProperties();

        public virtual T Clone<T>()
        {
            return (T)Clone();
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        public virtual bool Validate()
        {
            ValidateProperties();
            return Valid;
        }
        #endregion

        #region Object overrides
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var item = (BaseEntity)obj;

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }

            return EqualityComparer<BaseEntity>.Default.Equals(item, this);
        }

        public override int GetHashCode()
        {
            const int INDEX = 1;
            var hashCode = 31;
            var changeMultiplier = false;

            // Compare all public properties.
            var publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                foreach (var prop in publicProperties)
                {
                    var value = prop.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = hashCode * ((changeMultiplier ? 59 : 114) + value.GetHashCode());
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        // Only for support {"a",null,null,"a"} <> {null,"a","a",null}
                        hashCode = hashCode ^ (INDEX * 13);
                    }
                }
            }

            return hashCode;
        }
        #endregion
    }
}
