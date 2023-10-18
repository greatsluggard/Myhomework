using System;

namespace Task1
{
    interface IMyTask<TResult>
    {
        TResult Result { get; set; }
        TResult GetResult();
        bool IsCompleted { get; set; }

        TResult ContinueWith(Func<TResult, TResult> taskContinuation);
    }
}
