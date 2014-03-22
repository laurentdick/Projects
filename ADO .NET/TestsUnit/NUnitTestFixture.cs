using System;
using NUnit.Framework;

namespace TestsUnit
{
    [TestFixture]
    public class NUnitTestFixture : AssertionHelper
    {
        public NUnitTestFixture()
        {
            Console.WriteLine("constructeur");
        }
        [SetUp]
        public void avant()
        {
            Console.WriteLine("Setup");
        }
        [TearDown]
        public void après()
        {
            Console.WriteLine("TearDown");
        }
        [Test]
        public void t1()
        {
            Console.WriteLine("test1");
            Assert.AreEqual(1, 1);
        }
        [Test]
        public void t2()
        {
            Console.WriteLine("test2");
            Expect(1, EqualTo(2), "1 n'est pas égal à 2");
        }
        [Test]
        public void t3()
        {
            Console.WriteLine("test3");

            bool vrai = true, faux = false;
            Expect(vrai, True);
            Expect(faux, False);

            Object obj1 = new Object(), obj2 = null, obj3 = obj1;
            Expect(obj1, Not.Null);
            Expect(obj2, Null);
            Expect(obj3, SameAs(obj1));

            double d1 = 4.1, d2 = 6.4, d3 = d1;
            Expect(d1, EqualTo(d3).Within(1e-6));
            Expect(d1, Not.EqualTo(d2));
        }
    }
}

