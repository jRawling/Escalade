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
        [Description("Male")]
        Male = 0,
        [Description("Female")]
        Female = 1,
        [Description("Prefer not to say")]
        Unspecified = 2
    }
}

namespace Escalade.Domain.Identity
{
    public enum PasswordVerificationResult
    {
        /// <summary>
        ///   Password verification failed
        /// </summary>
        Failed = 0,
        /// <summary>
        ///  Success
        /// </summary>
        Success = 1,
        /// <summary>
        ///    Success but should update and rehash the password
        /// </summary>
        SuccessRehashNeeded = 2
    }
}