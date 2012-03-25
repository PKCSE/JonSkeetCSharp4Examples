using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Examples
{
    [TestFixture]
    public class ControlFlowExample
    {
        [Test]
        public void Return_Is_The_Simplest_Form_Of_Flow_Control()
        {
            Console.WriteLine("Hello");

            return;
            Console.WriteLine("This code is not reachable.");
        }
    }
}
