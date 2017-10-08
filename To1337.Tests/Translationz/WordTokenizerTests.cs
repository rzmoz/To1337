using System.Linq;
using FluentAssertions;
using To1337.Translationz;
using Xunit;

namespace To1337.Tests.Translationz
{
    public class WordTokenizerTests
    {
        private readonly WordTokenizer _wordTokenizer;

        public WordTokenizerTests()
        {
            _wordTokenizer = new WordTokenizer();
        }

        [Theory]
        [InlineData("I expect four tokens", 4)] //plain text
        [InlineData("I expect<br />five tokens", 5)] //when tag is not wrapped in spaces
        [InlineData("I expect <br /> five tokens", 5)] //when tag is wrapped nicely in spaces
        [InlineData("I expect\r\n<br />\r\nfive tokens", 5)] //when tag is wrapped in line breaks
        [InlineData("I expect<br />\r\n five tokens", 5)] //when tag is wrapped in line breaks and spaces
        public void TokenizeString_TokenizeString_ProperTokenCountCreated(string input, int expectedTokens)
        {
            var result = _wordTokenizer.TokenizeString(input);
            result.Count().Should().Be(expectedTokens);
        }

        [Theory]
        [InlineData("not html\r\n<br />\r\nnot html")] //when tag is wrapped in line break carriage return
        [InlineData("not html<br />not html")] //when tag is not wrapped in spaces
        [InlineData("not html <br /> not html")] //when tag is wrapped nicely in spaces
        public void TokenizeString_DetectHtmlTagsWhenNiceSpacing_TagsAreDetected(string input)
        {
            var result = _wordTokenizer.TokenizeString(input).ToArray();

            var htmlTag = result[2];
            //assert we have the break tag
            htmlTag.Should().Be("<br />");
        }

        [Fact]
        public void EncodeHtmlTagSpaces_SpacesInTagesAreMarked()
        {
            const string input = "not html <br /> not html <br /> not html";
            string[] expected = { "not", "html", "<br />", "not", "html", "<br />", "not", "html" };

            var result = _wordTokenizer.TokenizeString(input);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
