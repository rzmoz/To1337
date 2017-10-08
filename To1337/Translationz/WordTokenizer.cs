using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace To1337.Translationz
{
    public class WordTokenizer : IWordTokenizer
    {
        private const char _splitChar = '←';
        private static readonly string _trimMultipleSplitsPattern = "[" + _splitChar + "]{2,}";
        private static readonly Regex _multipleSplitsRegex = new Regex(_trimMultipleSplitsPattern, RegexOptions.Compiled);

        public WordTokenizer()
        {
            Splits = new HashSet<char> { ' ', '\r', '\n' };
        }

        public ISet<char> Splits { get; }

        public IReadOnlyCollection<string> TokenizeString(string input)
        {
            var formattedString = new StringBuilder(input.Length);

            var isInHtmlTag = false;

            foreach (var c in input)
            {
                switch (c)
                {
                    case '<':
                        isInHtmlTag = true;
                        formattedString.Append(_splitChar);
                        formattedString.Append(c);
                        break;
                    case '>':
                        isInHtmlTag = false;
                        formattedString.Append(c);
                        formattedString.Append(_splitChar);
                        break;
                    default:
                        if (isInHtmlTag == false)
                        {
                            if (Splits.Contains(c))
                            {
                                formattedString.Append(_splitChar);
                                continue;
                            }
                        }
                        formattedString.Append(c);
                        break;
                }
            }

            var trimSplits = _multipleSplitsRegex.Replace(formattedString.ToString(), _splitChar.ToString());
            return trimSplits.Split(_splitChar);
        }
    }
}
