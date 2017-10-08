using System;
using System.Collections.Generic;
using System.Linq;
using To1337.Translationz;

namespace To1337.Rulez
{
    public struct Rule : IComparable<Rule>
    {
        private static readonly Random _rand = new Random();

        public Rule(string trigger, Translation translation)
            : this(trigger, new List<Translation> { translation })
        { }

        public Rule(string trigger, IReadOnlyCollection<Translation> translationz) : this()
        {
            if (string.IsNullOrEmpty(trigger)) throw new ArgumentException("trigger is null or empty");
            if (translationz == null) throw new ArgumentNullException(nameof(translationz));

            Trigger = trigger;
            Translationz = translationz.ToList();
        }

        /// <summary>
        /// order by trigger length descending
        /// </summary>
        /// <param name="otherRule">The other rule.</param>
        /// <returns></returns>
        public int CompareTo(Rule otherRule)
        {
            return Trigger.Length.CompareTo(otherRule.Trigger.Length);
        }


        public string Apply(string input, L337ness l337ness)
        {
            var translation = GetTranslation(l337ness);
            if (translation.IsEmpty)
                return input;
            input += " ";
            return translation.Translate(input, Trigger).TrimEnd();
        }


        public IReadOnlyCollection<Translation> Translationz { get; }
        public string Trigger { get; }

        public bool Equals(Rule other)
        {
            return Equals(other.Trigger, Trigger) && other.Translationz.SequentialEquals(Translationz);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Rule)) return false;
            return Equals((Rule)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Translationz != null ? Translationz.GetHashCode() : 0) * 397) ^ (Trigger != null ? Trigger.GetHashCode() : 0);
            }
        }

        /// <summary>
        /// pre: translations  is NOT empty - throws exception if empty
        /// </summary>
        /// <param name="translations"></param>
        /// <param name="index"></param>
        /// <param name="sum"></param>
        /// <param name="rand"></param>
        /// <returns></returns>
        private static Translation RandomizeTranslationByWeight(IReadOnlyCollection<Translation> translations, int index, int sum, int rand)
        {
            if (!translations.Any())
                throw new ArgumentException("no translations was given! (translation is empty)");
            var transAsList = translations.ToList();
            sum = sum - transAsList[index].Weight;
            if (sum <= rand)
                return transAsList[index];
            return RandomizeTranslationByWeight(translations, ++index, sum, rand);
        }

        /// <summary>
        /// Gets the translation.
        /// </summary>
        /// <param name="l337ness">The l337ness.</param>
        /// <returns></returns>
        private Translation GetTranslation(L337ness l337ness)
        {
            //if no translations are found, no translation is made
            if (Translationz.Any() == false)
                return new Translation();

            //find translations where 1337nes is within boundaries
            var resolvedTranslationz = Translationz.Where(t => t.L337ness <= l337ness).ToList();

            //if no translations where 1337nes is within boundaries is found, no translation is made
            if (resolvedTranslationz.Any() == false)
                return new Translation();

            //calculate randomize sum
            var weigthSum = resolvedTranslationz.Sum(t => t.Weight);

            return RandomizeTranslationByWeight(resolvedTranslationz, 0, weigthSum, _rand.Next(weigthSum));
        }
    }
}
