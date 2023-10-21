using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Task1
{
    public class MyThreadPool
    {
        private BlockingCollection<Action> queueTask = new BlockingCollection<Action>();
        private CancellationTokenSource stopToken = new CancellationTokenSource();
        private int threadsCompletedWork = 0;

        public int NumberOfThreads { get; }
        public bool ThreadPoolIsClosed => NumberOfThreads == threadsCompletedWork;

        public MyThreadPool (int numberOfThreads)
        {
            NumberOfThreads = numberOfThreads;
            CreateThreads(numberOfThreads);
        }

        private void CreateThreads(int numberOfThreads)
        {
            for (var i = 0; i < numberOfThreads; ++i)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        if (stopToken.Token.IsCancellationRequested)
                        {
                            Interlocked.Increment(ref threadsCompletedWork);
                            break;
                        }

                        queueTask?.Take().Invoke();
                    }
                }).Start();
            }
        }


        public IMyTask<TResult> AddTask<TResult>(Func<TResult> func)                      
        {
            if (stopToken.Token.IsCancellationRequested)                                  
            {
                throw new InvalidOperationException("Thread pool has been shutted down");
            }

            var task = new MyTask<TResult>(func, this);

            try
            {
                queueTask.Add(task.Calculate, stopToken.Token);                      
            }
            catch
            {
                throw new InvalidOperationException("Thread pool has been shutted down");
            }

            return task;
        }

        public void Shutdown()                                                           
        {
            stopToken.Cancel();
            queueTask?.CompleteAdding();
            queueTask = null;
        }

        private Action AddAction(Action action)                                         
        {
            queueTask.Add(action, stopToken.Token);                                      

            return action;
        }

        private class MyTask<TResult> : IMyTask<TResult>
        {
            private MyThreadPool threadPool;                                                                     
            private Func<TResult> function;                                                                      
            private ManualResetEvent waitHandler = new ManualResetEvent(false);                                 
            private AggregateException exception;                                                                
            private Queue<Action> localQueue;                                                                    
            private TResult result;                                                                              
            private object locker = new object();                                                               

            public bool IsCompleted { get; private set; } = false;                                                

            public TResult Result                                                                                
            {
                get
                {
                    waitHandler.WaitOne();
                    if (exception == null)
                    {
                        return result;
                    }

                    throw exception;
                }
            }

            public MyTask(Func<TResult> task, MyThreadPool threadPool)
            {
                function = task;
                this.threadPool = threadPool;
                localQueue = new Queue<Action>();
            }

            public void Calculate()
            {
                try
                {
                    result = function();
                }
                catch (Exception ex)
                {
                    exception = new AggregateException(ex);
                }
                finally
                {
                    lock (locker)
                    {
                        IsCompleted = true;
                        function = null;
                        waitHandler.Set();

                        while (localQueue.Count != 0)
                        {
                            threadPool.AddAction(localQueue.Dequeue());
                        }
                    }
                }
            }

            public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
            {
                var newTask = new MyTask<TNewResult>(() => func(Result), threadPool);

                lock (locker)
                {
                    if (IsCompleted)
                    {
                        return threadPool.AddTask(() => func(Result));
                    }

                    localQueue.Enqueue(newTask.Calculate);
                    return newTask;
                }
            }
        }
    }
}