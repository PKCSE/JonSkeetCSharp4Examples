using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Examples
{
    [TestFixture]
    public class LinqExamples
    {
        private List<string> _names;
        private Regex _pattern;

        [SetUp]
        public void BeforeEachTest()
        {
            _names = new List<string> { "Rob, Friend", "Holly, Family", "This isn't a name", "Malcolm, Colleague", "Tom, Family" };
            _pattern = new Regex("([^,]*), (.*)");
        }

        [Test]
        public void Linq_With_Introduced_Variable()
        {
            var query = from line in _names
                        let match = _pattern.Match(line)
                        where match.Success
                        select new
                                   {
                                       Name = match.Groups[1].Value,
                                       Relationship = match.Groups[2].Value
                                   }
                        into association
                        group association.Name by association.Relationship;

            foreach (var group in query)
            {
                Console.WriteLine("Relationship: {0}", group.Key);
                foreach (var name in group)
                {
                    Console.WriteLine("  {0}", name);
                }
            }


        }

        [Test]
        public void Linq_With_Introduced_Variable_Method_Chaining()
        {
            var query = _names.Select(line => new {line, match = _pattern.Match(line)})
                              .Where (z => z.match.Success)
                              .Select(z => new
                                                 {
                                                     Name = z.match.Groups[1].Value,
                                                     Relationship = z.match.Groups[2].Value
                                                 })
                              .GroupBy( association => association.Relationship, 
                                        association => association.Name);

            foreach (var group in query)
            {
                Console.WriteLine("Relationship: {0}", group.Key);
                foreach (var name in group)
                {
                    Console.WriteLine("  {0}", name);
                }
            }


        }
    }
}
