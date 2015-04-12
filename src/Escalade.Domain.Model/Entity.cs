using System;

namespace Escalade.Domain.Model
{
    public class Entity
    {
        public static string Normalise(string field)
        {
            return field.ToLowerInvariant();
        }
    }
}