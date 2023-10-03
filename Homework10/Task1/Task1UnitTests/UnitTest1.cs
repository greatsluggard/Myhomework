using NUnit.Framework;
using Task1;

namespace Task1UnitTests
{
    public class Tests
    {
        [Test]
        public void Get—orrectValue()
        {
            Lazy lazySingleThreadMode = LazyFactory.CreateSingleThreadMode(22, 7);
            int expected = 29;

            Assert.AreEqual(expected, lazySingleThreadMode.Get());
        }

        [Test]
        public void TryBelowZeroValue()
        {
            Lazy lazySingleThreadMode;
            Assert.Catch<ArgumentException>(() => lazySingleThreadMode = LazyFactory.CreateSingleThreadMode(-9, -5));
        }
        [Test]
        public void CorrectRepeatCall()
        {
            Lazy lazySingleThreadMode = LazyFactory.CreateSingleThreadMode(10, 50);
           
            Console.WriteLine(lazySingleThreadMode.Get());
            Console.WriteLine(lazySingleThreadMode.Get());
            Console.WriteLine(lazySingleThreadMode.Get());

            int expected = 60;

            Assert.AreEqual(expected, lazySingleThreadMode.Get());
        }
        [Test] 
        public void IsNoRaceConditions()
        {
            (Lazy, bool) lazyMultiThreadMode = LazyFactory.CreateMultiThreadMode(20, 20);
            Assert.IsTrue(lazyMultiThreadMode.Item2);
        }
    }
}