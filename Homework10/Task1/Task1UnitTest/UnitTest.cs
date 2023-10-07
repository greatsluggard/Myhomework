using Task1;
using NUnit.Framework;

namespace Task1UnitTest
{
    public class Tests
    {
        [Test]
        public void CorrectRepeatCall()
        {
            Random random = new Random();
            Func<int> supplier = delegate { return random.Next(100) * 2; };
            LazyForSingleThread<int> lazySingleMode = LazyFactory.CreateSingleThread(supplier);

            bool isCorrect = true;
            int currentValue;
            int previousValue = lazySingleMode.Get();
            for (int i = 0; i < 100; i++)
            {
                currentValue = lazySingleMode.Get();
                if (currentValue != previousValue)
                {
                    isCorrect = false;
                }
                previousValue = currentValue;
            }
            Assert.AreEqual(true, isCorrect);
        }

        [Test]
        public void CorrectThreadStateOperation()
        {
            Func<string> supplier = delegate { return "Some text"; };
            LazyForSingleThread<string> lazySingleMode = LazyFactory.CreateSingleThread(supplier);
            Thread thread = new Thread(() => lazySingleMode.Get());
            thread.Start();
            thread.Join();

            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine(i);
            }

            System.Threading.ThreadState state = System.Threading.ThreadState.Stopped;
            System.Threading.ThreadState currentThreadState = thread.ThreadState;

            Assert.AreEqual(state, currentThreadState);
        }

        [Test]
        public void IsFuncBackNull()
        {
            string nothing = null;

            Func<string> supplier = delegate { return nothing; };
            LazyForSingleThread<string> lazySingleMode = LazyFactory.CreateSingleThread(supplier);

            string back = lazySingleMode.Get();

            Assert.AreEqual(null, back);
        }

        [Test] 
        public void IsSynchronizationMinimized()
        {
            Random random = new Random();
            Func<int> supplier = delegate { return random.Next(100) * 2; };
            LazyForMultiThread<int> lazyMultiMode = LazyFactory.CreateMultiThread(supplier);

            for (int i = 1; i < 6; i++)
            {
                Thread multiThread = new Thread(() => lazyMultiMode.Get());
                multiThread.Start();
            }

            int count = lazyMultiMode.Count;

            Assert.AreEqual(1, count);
        }

        [Test]
        public void IsThreadsInRaceCondition()
        {
            bool isRace = false;
            Random random = new Random();
            Func<int> supplier = delegate { return random.Next(100) * 2; };
            LazyForMultiThread<int> lazyMultiMode = LazyFactory.CreateMultiThread(supplier);

            for (int i = 1; i < 6; i++)
            {
                Thread multiThread = new Thread(() => lazyMultiMode.Get());
                multiThread.Start();
                if (lazyMultiMode.CountOfThreads > 1)
                {
                    isRace = true;
                }
            }
            Assert.AreEqual(false, isRace);
        }
    }
}