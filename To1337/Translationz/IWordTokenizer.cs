using System.Collections.Generic;

namespace To1337.Translationz
{
    public interface IWordTokenizer
    {
        IReadOnlyCollection<string> TokenizeString(string input);
    }
}
