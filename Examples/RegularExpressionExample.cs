using System.Text.RegularExpressions;
using NUnit.Framework;
namespace Examples
{
    [TestFixture]
    public class RegularExpressionExample
    {
        private string _sampleLine;

        [SetUp]
        public void BeforeEachTest()
        {
            _sampleLine = "WARNING 05/10/2011 13:15:15.000 ---FooBar--- The foo has been barred.";
        }

        [Test]
        public void Regex_Can_Have_Name()
        {
            var pattern = new Regex(@"(?<level>\S+) ");
            var match = pattern.Match(_sampleLine);

            Assert.That(match.Groups["level"].Value, Is.EqualTo("WARNING"));
        }

        [Test]
        public void First_Word_In_A_Line()
        {
            var pattern = new Regex(@"(?<level>\S+) ");
            var match = pattern.Match(_sampleLine);

            Assert.That(match.Groups["level"].Value, Is.EqualTo("WARNING"));
        }

        [Test]
        public void Time_Stamp()
        {
            var pattern = new Regex(@"(?<timestamp>\d{2}/\d{2}/\d{4} \d{2}:\d{2}:\d{2}\.\d{3}) ");
            var match = pattern.Match(_sampleLine);

            Assert.That(match.Groups["timestamp"].Value, Is.EqualTo("05/10/2011 13:15:15.000"));
        }

        [Test]
        public void Negation()
        {
            var pattern = new Regex(@"---(?<category>[^-]+)--- ");
            var match = pattern.Match(_sampleLine);

            Assert.That(match.Groups["category"].Value, Is.EqualTo("FooBar"));
        }
    }
}