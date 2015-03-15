using System;

namespace Escalade.Domain.Model
{
    public class Entity
    {
        protected string Normalise(string field)
        {
            return field.ToLowerInvariant();
        }
    }
}