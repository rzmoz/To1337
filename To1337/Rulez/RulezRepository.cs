using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using To1337.Translationz;

namespace To1337.Rulez
{
    public class RulezRepository : IReadOnlyCollection<Rule>
    {
        private const string _triggerAttribute = "trigger";
        private const string _ruleName = "rule";
        private const string _translationValueAttribute = "value";
        private const string _translationMaxL337NessAttribute = "maxL337ness";
        private const string _translationWeightAttribute = "weight";

        private readonly IList<Rule> _rulez;

        public RulezRepository()
        {
            _rulez = GetDefaultTranslations().ToList();
        }

        private IEnumerable<Rule> GetDefaultTranslations()
        {
            using (var rulezStream = typeof(RulezRepository).Assembly.GetManifestResourceStream("To1337.Rulez.DefaultRulez.xml"))
            using (var reader = new StreamReader(rulezStream))
            {

                var defaultRules = XDocument.Parse(reader.ReadToEnd());
                var rulez = defaultRules.Descendants(_ruleName);

                return from rule in rulez
                       let trigger = rule.Attribute(_triggerAttribute).Value
                       let translations = ReadTranslation(rule.Descendants())
                       select new Rule(trigger, translations.ToList());
            }
        }

        private IEnumerable<Translation> ReadTranslation(IEnumerable<XElement> translations)
        {
            return from translation in translations
                   let name = translation.Attribute(_translationValueAttribute).Value
                   let l337ness = translation.Attribute(_translationMaxL337NessAttribute).Value.ToEnum<L337ness>()
                   let weight = translation.Attribute(_translationWeightAttribute).Value
                   select new Translation(name, l337ness, Convert.ToInt32(weight));
        }

        public IEnumerator<Rule> GetEnumerator()
        {
            return _rulez.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _rulez.Count;
    }
}
