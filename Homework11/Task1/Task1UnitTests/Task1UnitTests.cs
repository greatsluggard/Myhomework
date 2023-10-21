using NUnit.Framework;
using Task1;

namespace Task1UnitTests
{
    public class Tests
    {
        [Test]
        public void IsNThreads()
        {
            MyThreadPool pool = new MyThreadPool(5);
            Assert.AreEqual(5, pool.NumberOfThreads);
        }

        [Test]
        public void IsCorrectThreadsWork()
        {
            MyThreadPool pool = new MyThreadPool(5);
            Random random = new Random();
            int correctCompleteTasks = 0;

            for (int i = 0; i < 100; i++)
            {
                Func<int> func = () => random.Next(100) * 2;
                var result = pool.AddTask(func);
                Thread.Sleep(100);

                if (result.IsCompleted == true) correctCompleteTasks++;
            }
            pool.Shutdown();

            Assert.AreEqual(100, correctCompleteTasks);
        }

        [Test]
        public void IsCorrectShutdown()
        {
            MyThreadPool pool = new MyThreadPool(5);
            Random random = new Random();

            Assert.Catch<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 100; ++i)
                {
                    if (i > 50)
                    {
                        pool.Shutdown();
                    }

                    Func<int> func = () => random.Next(100) * 2;

                    var result = pool.AddTask(func);
                }
            });
        }

        [Test]
        public void IsCorrectContinueWith()
        {
            MyThreadPool pool = new MyThreadPool(5);
            var task = pool.AddTask<int>(() => 2 * 2).ContinueWith(x => x.ToString());
            Assert.AreEqual ("4", task.Result);
        }
    }
}