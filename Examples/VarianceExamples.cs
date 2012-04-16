using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Examples
{
    public interface IEdile {}
    public abstract  class Fruit : IEdile  {}
    public class Apple : Fruit {}
    public class Banana : Fruit {}
    public class Pizza : IEdile {}

    public interface IFoo<out T> // this T is covariant
    {
        T GiveMeFoo();
    }

    [TestFixture]
    public class VarianceExamples
    {
        [Test]
        public void Going_To_General_From_Specific_Is_Covariant()
        {
            IFoo<string> foos = null;
            IFoo<object> general = foos;
        }

        [Test]
        public void IEnumerable_Is_Covariant()
        {
            var bananas = new List<Banana>();

            IEnumerable<Fruit> fruits = bananas; //IEnumerable is co-variant
            EatAll(fruits);
        }

        private void EatAll(IEnumerable<IEdile> edibles)
        {
            Console.WriteLine(edibles.GetType());
            foreach (var edible in edibles)
            {
                // do something in here
            }
        }
    }
}
