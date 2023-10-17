using System;
using System.Threading;

namespace Task1
{
    interface IMyTask<TResult>
    {
        TResult Result { get; set; }
        TResult GetResult();
        bool IsCompleted { get; set; }

        //Func<TResult> ContinueWith(Func<TResult, TResult> taskContinuation);
    }
}
