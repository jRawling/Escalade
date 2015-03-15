using Escalade.Domain.Attributes;

namespace Escalade.Domain
{
    public enum Country
    {
        [CountryInfoAttribute("GBR", "United Kingdom")]
        UnitedKingdom = 826,
        [CountryInfoAttribute("DEU", "Germany")]
        Germany = 276,
        [CountryInfoAttribute("FRA", "France")]
        France = 250,
        [CountryInfoAttribute("NLD", "Netherlands")]
        Netherlands = 528,
        [CountryInfoAttribute("SWE", "Sweden")]
        Sweden = 752
    }

    public enum Gender
    {
        Unspecified = 0,
        Male = 1,
        Female = 2
    }
}