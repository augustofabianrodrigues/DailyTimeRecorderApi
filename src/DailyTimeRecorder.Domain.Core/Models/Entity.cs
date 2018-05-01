using System;
using System.Collections.Generic;

namespace DailyTimeRecorder.Domain.Core.Models
{
    public abstract class Entity : IEquatable<Entity>
    {
        #region Constructor
        protected Entity(long id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        public long Id { get; private set; }
        #endregion

        #region Operators
        public static bool operator !=(Entity entity1, Entity entity2)
        {
            return !(entity1 == entity2);
        }

        public static bool operator ==(Entity entity1, Entity entity2)
        {
            return EqualityComparer<Entity>.Default.Equals(entity1, entity2);
        }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public bool Equals(Entity other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType()} [Id={Id}]";
        }
        #endregion
    }
}
