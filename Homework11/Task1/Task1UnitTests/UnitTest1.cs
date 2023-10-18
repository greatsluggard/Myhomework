using NUnit.Framework;
using Task1;

namespace Task1UnitTests
{
    public class Tests
    {
        [Test]
        public void IsNThreads()
        {
            MyThreadPool<int> pool = new MyThreadPool<int>(10);

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                pool.AddTask(() => random.Next(100));
            }

            bool isNThreads = false;
            if (pool._countOfThreads == 10)
            {
                isNThreads = true;
            }

            Assert.AreEqual(true, isNThreads);
        }
    }
}