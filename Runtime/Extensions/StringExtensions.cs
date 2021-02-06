using System.Text;

namespace Zigurous.DataStructures
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str) => str == null || str.Length <= 0;
        public static bool IsNotEmpty(this string str) => !IsEmpty(str);

        public static string Repeat(this string str, int n)
        {
            return new StringBuilder(str.Length * n)
                .Insert(0, str, n)
                .ToString();
        }

        [System.Serializable]
        public struct NumberAbbreviation
        {
            public float factor;
            public string format;

            public NumberAbbreviation(float factor, string format)
            {
                this.factor = factor;
                this.format = format;
            }

        }

        private static readonly NumberAbbreviation[] abbreviations = new NumberAbbreviation[4] {
            new NumberAbbreviation(1_000_000_000_000, "0T"),
            new NumberAbbreviation(1_000_000_000, "0B"),
            new NumberAbbreviation(1_000_000, "0M"),
            new NumberAbbreviation(1_000, "0K"),
        };

        public static string ToAbbreviatedString(this float number) => ToAbbreviatedString(number, StringExtensions.abbreviations);
        public static string ToAbbreviatedString(this float number, NumberAbbreviation[] abbreviations)
        {
            float abs = System.Math.Abs(number);

            for (int i = 0; i < abbreviations.Length; i++)
            {
                NumberAbbreviation abbreviation = abbreviations[i];

                if (abs >= abbreviation.factor) {
                    return (number / abbreviation.factor).ToString(abbreviation.format);
                }
            }

            return number.ToString();
        }

    }

}
