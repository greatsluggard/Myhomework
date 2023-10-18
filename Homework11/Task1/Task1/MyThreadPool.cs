using System;
using System.Threading;
using System.Collections;

namespace Task1
{
    public class MyThreadPool<TResult> : IMyTask<TResult>
    {
        static Queue _queue = new Queue();
        private Thread _thread;
        private Func<TResult> _task;
        private int _countOfСompletedTask = 0;   //...Для условия закрытия потоков через ShutDown
        public int _countOfThreads = 0;          //...Для юнит-теста

        public TResult Result { get; set; }
        public TResult ResultForContinueWith { get; set; }
 
        public bool IsCompleted { get; set; }

        static CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;

        object locker = new object();

        public MyThreadPool(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _thread = new Thread(() => StartThread());
                _thread.Start();
                _countOfThreads++;
            }
        }

        private void StartThread()
        {
            while (true)
            {
                lock (_queue)
                {
                    if (_queue.Count > 0)
                    {
                        _task = (Func<TResult>)_queue.Dequeue();
                        IsCompleted = true;
                        GetResult();
                        _countOfСompletedTask++;
                    }
                    else
                    {
                        if (ShutDown() == true)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public TResult AddTask(Func<TResult> task)
        {
            _queue.Enqueue(task);
            _queue.TrimToSize();
            ResultForContinueWith = task();
            return ResultForContinueWith;
        }

        public TResult ContinueWith (Func<TResult, TResult> task)
        {
            TResult result = task(ResultForContinueWith);
            Console.WriteLine("Тут выполнился метод ContinueWith " + result);
            return result;
        }

        public TResult GetResult()
        {
            lock (locker)
            {
                try
                {
                    Result = _task();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":   " + Result);
                return Result;
            }
        }

        private bool ShutDown()
        {
            if (_countOfСompletedTask >= 50)
            {
                source.Cancel();
            }
            if (token.IsCancellationRequested)
            {
                Console.WriteLine($"Operation returned and thread №{Thread.CurrentThread.ManagedThreadId} is stopped");
                return true;
            }
            return false;
        }
    }
}