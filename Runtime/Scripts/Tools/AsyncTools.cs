using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Tools
{
    public static class AsyncTools
    {
        public static async UniTask WaitWhileWithoutSkippingFrame(Func<bool> func, CancellationToken cancellationToken = default)
        {
            var result = func.Invoke();

            if (!result)
                return;
            
            await UniTask.WaitWhile(func, cancellationToken: cancellationToken);
        }
    }
}