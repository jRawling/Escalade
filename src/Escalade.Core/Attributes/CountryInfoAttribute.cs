using System.ComponentModel;

namespace Escalade.Core.Attributes
{
    internal class CountryDescriptionAttribute : DescriptionAttribute
    {
        internal CountryDescriptionAttribute(string threeLetterIso, string description)
            : base(description)
        {
            ThreeLetterIso = threeLetterIso;
        }

        public string ThreeLetterIso { get; }
    }
}