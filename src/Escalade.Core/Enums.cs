using Escalade.Core.Attributes;
using System.ComponentModel;

namespace Escalade.Core
{
    public enum Country
    {
        [CountryDescription("GBR", "United Kingdom")]
        UnitedKingdom = 826,
        [CountryDescription("DEU", "Germany")]
        Germany = 276,
        [CountryDescription("FRA", "France")]
        France = 250,
        [CountryDescription("NLD", "Netherlands")]
        Netherlands = 528,
        [CountryDescription("SWE", "Sweden")]
        Sweden = 752
    }

    public enum Gender
    {
        [Description("Prefer not to say")]
        Unspecified = 0,
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2
    }
}