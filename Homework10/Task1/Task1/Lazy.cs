using System;

namespace Task1
{
    public class LazyForSingleThread<T> : ILazy<T>
    {
        private Func<T> _supplier;
        private T _value;
        private bool _isValueCreated;

        public LazyForSingleThread(Func<T> supplier)
        {
            _supplier = supplier;
            _isValueCreated = false;
        }

        public T Get()
        {
            if (!_isValueCreated)
            {
                _value = _supplier();
                _isValueCreated = true;
            }

            Console.WriteLine(_value);
            return _value == null ? default : _value;
        }
    }
    public class LazyForMultiThread<T> : ILazy<T>
    {
        private object _lock = new object();
        private Func<T> _supplier;
        private T _value;
        private bool _isValueCreated;
        public int Count { get; set; } //для отслеживания минимизации синхронизаций
        public int CountOfThreads { get; set; } //переменная для отслеживания, какое кол-во потоков в данный момент пытается использовать блок кода

        public LazyForMultiThread(Func<T> supplier)
        {
            _supplier = supplier;
            _isValueCreated = false;
        }

        public T Get()
        {
            if (!_isValueCreated)
            {
                lock (_lock)
                {
                    Count++;
                    CountOfThreads++;
                    if (!_isValueCreated)
                    {
                        _value = _supplier();
                        _isValueCreated = true;
                    }
                    CountOfThreads--;
                }
            }
            Console.WriteLine(_value);
            return _value;
        }
    }

    public class LazyFactory
    {
        public static LazyForSingleThread<T> CreateSingleThread<T>(Func<T> supplier)
        {
            return new LazyForSingleThread<T>(supplier);
        }

        public static LazyForMultiThread<T> CreateMultiThread<T>(Func<T> supplier)
        {
            return new LazyForMultiThread<T>(supplier);
        }
    }
}