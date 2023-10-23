using System;

namespace Task1
{
    public interface IMyTask<TResult>
    {
        TResult Result { get; }
        bool IsCompleted { get; }

        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
