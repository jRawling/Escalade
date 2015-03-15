using System;
using System.ComponentModel;

namespace Escalade.Domain.Attributes
{
    public class CountryInfoAttribute : DescriptionAttribute
    {
        internal CountryInfoAttribute(string threeLetterIso, string name)
        {
            ThreeLetterIso = threeLetterIso;
            Name = name;
        }
        public string ThreeLetterIso { get; }
        public string Name { get; }
    }
}