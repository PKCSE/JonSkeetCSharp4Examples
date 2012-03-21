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
        public void Parse_Exact()
        {
            var date = DateTime.ParseExact("05/10/2011 13:15:15.000", "dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

            Assert.That(date.Month, Is.EqualTo(10));
            Assert.That(date.Year, Is.EqualTo(2011));
            Assert.That(date.Day, Is.EqualTo(05));
        }

        [Test]
        public void TimeSpan_From_Is_More_Readable()
        {
            var fiveSeconds1 = TimeSpan.FromSeconds(5);
            var fiveSeconds2 = new TimeSpan(0, 0, 5);

            Assert.That(fiveSeconds1, Is.EqualTo(fiveSeconds2));

        }

        [Test]
        public void TimeSpan_Milliseconds_Returns_Only_Milliseconds_Part()
        {
            var tenMinute = TimeSpan.FromMinutes(10);

            Assert.That(tenMinute.Milliseconds, Is.EqualTo(0));
        }



    }
}
