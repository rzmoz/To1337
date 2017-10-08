using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using To1337.Rulez;

namespace To1337.Translationz
{
    public class L337Translator : IL337Translator
    {
        private readonly IList<Rule> _rulez; //list of rules
        private readonly IWordTokenizer _wordTokenizer;

        public L337Translator()
            : this(new RulezRepository(), new WordTokenizer())
        { }

        public L337Translator(IReadOnlyCollection<Rule> rulez, IWordTokenizer wordTokenizer)
        {
            if (rulez == null) throw new ArgumentNullException(nameof(rulez));

            _rulez = rulez.OrderByDescending(x => x).ToList();

            _wordTokenizer = wordTokenizer;
        }

        public string To1337(string input, L337ness l337ness = L337ness.L337)
        {
            if (input == string.Empty)
                return input;

            var words = _wordTokenizer.TokenizeString(input).ToArray();
            var returnString = new StringBuilder();

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith("<"))
                {
                    returnString.Append(" " + words[i]);
                    continue;
                }

                foreach (var rule in _rulez)
                {
                    words[i] = rule.Apply(words[i], l337ness);
                }

                returnString.Append(" " + words[i]);
            }
            return returnString.ToString().TrimStart();
        }
    }
}
