using To1337.Translationz;

namespace To1337
{
    public static class StringExtensions
    {
        private static readonly IL337Translator _translator = new L337Translator();
        
        public static string To1337(this string input, L337ness l337ness = L337ness.L337)
        {
            return _translator.To1337(input, l337ness);
        }
    }
}
