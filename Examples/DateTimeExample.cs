using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Examples
{
    [TestFixture]
    public class DateTimeExample
    {
        [Test]
        public void ParseExact()
        {
            var date = DateTime.ParseExact("05/10/2011 13:15:15.000", "dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

            Assert.That(date.Month, Is.EqualTo(10));
            Assert.That(date.Year, Is.EqualTo(2011));
            Assert.That(date.Day, Is.EqualTo(05));
        }
    }
}
