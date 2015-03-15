using Escalade.Domain.Attributes;

namespace Escalade.Domain.Extentions
{
    public static class CountryExtentions
    {
        public static string GetThreeLetterIso (this Country country)
        {
            var attribute = country.GetAttribute<CountryInfoAttribute>();
            return (attribute == null ? string.Empty : attribute.ThreeLetterIso);
        }

        public static string GetName(this Country country)
        {
            var attribute = country.GetAttribute<CountryInfoAttribute>();
            return (attribute == null ? string.Empty : attribute.Name);
        }
    }
}