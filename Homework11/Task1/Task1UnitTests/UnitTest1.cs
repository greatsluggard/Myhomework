using NUnit.Framework;
using Task1;

namespace Task1UnitTests
{
    public class Tests
    {
        [Test]
        public void IsNThreads()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Func<int> task = () => random.Next(100);
                MyThreadPool<int>.AddTask(task);
            }

            MyThreadPool<int> pool = new MyThreadPool<int>(10);
            bool isNThreads = false;
            if (pool._countOfThreads == 10)
            {
                isNThreads = true;
            }

            Assert.AreEqual(true, isNThreads);
        }
    }
}