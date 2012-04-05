using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Net;

namespace Examples
{
    [TestFixture]
    public class ExtensionMethodExamples
    {
        [Test]
        public void Reverse_String()
        {
            Assert.That("Hello".Reverse(), Is.EqualTo("olleH"));
        }

        [Test]
        public void Read_Fully()
        {
            var request = WebRequest.Create("http://www.google.com");
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    byte[] data = responseStream.ReadFully();
                    Console.WriteLine(data.Length);
                }
            }
        }
    }

    public static class Extensions
    {
        public static string Reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }

        public static byte[] ReadFully(this Stream input)
        {
            var output = new MemoryStream();
            var buffer = new byte[8192];
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
            return output.ToArray();
        }
    }
}
