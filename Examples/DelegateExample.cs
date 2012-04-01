using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Examples
{
    [TestFixture]
    public class DelegateExample
    {
        [Test]
        public void Method_Can_Be_Invoked_Via_Delegate()
        {
            var target = new Target("Jon");
            var action = new Int32Action(target.RandomRob);

            action.Invoke(5); //Invoke can be omitted.
            action(6);
        }

        [Test]
        public void Static_Method_Can_Be_Called_Via_Delegate()
        {
            var action = new Int32Action(Target.StaticRob1);

            action(5);
        }

        [Test]
        public void Delegates_Can_Be_Combined_For_Multicast()
        {
            var action1 = new Int32Action(Target.StaticRob1);
            var action2 = new Int32Action(Target.StaticRob2);

            var action3 = action1 + action2;
            action3(20);
        }
    }


    public delegate void Int32Action(int value);

    public class Target
    {
        private readonly string _name;

        public Target() : this("Unknown"){}
        public Target(string name)
        {
            _name = name;
        }

        public void RandomRob(int value)
        {
            Console.WriteLine("{0}: Delegate implementation: {1}", _name, value);
        }

        public static void StaticRob1(int value)
        {
            Console.WriteLine("Static method 1: {0}", value);
        }

        public static void StaticRob2(int value)
        {
            Console.WriteLine("Static method 2: {0}", value);
        }
    }
}
