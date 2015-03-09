using System;

namespace Escalade.Domain.Model
{
    public class Entity
    {
        /// <summary>
        /// A random value that should change whenever a user is persisted to the store.
        /// </summary>
        public string ConcurrencyStamp { get; private set; }
    }
}