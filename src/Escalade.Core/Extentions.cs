using Escalade.Core.Attributes;
using System;
using System.ComponentModel;
using System.Linq;

namespace Escalade.Core
{
    public static class EnumExtentions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static string GetThreeLetterIso(this Country country)
        {
            var attribute = country.GetAttribute<CountryDescriptionAttribute>();
            return (attribute == null ? string.Empty : attribute.ThreeLetterIso);
        }

        public static string GetDescription(this Country country)
        {
            var attribute = country.GetAttribute<DescriptionAttribute>();
            return (attribute == null ? string.Empty : attribute.Description);
        }

        public static string GetDescription(this Gender gender)
        {
            var attribute = gender.GetAttribute<DescriptionAttribute>();
            return (attribute == null ? string.Empty : attribute.Description);
        }
    }
}