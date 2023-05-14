// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

namespace Bnaya.Extensions.Common.Disposables
{
    public static class AsyncDisposable
    {
        #region Nop

        public static IAsyncDisposable Nop { get; } = new NopAsyncDisposable();

        #endregion // Nop

        #region Create

        public static IAsyncDisposable Create(Func<ValueTask> dispose, bool useFinalizerTrigger = false)
        {
            if (dispose == null)
                throw new ArgumentNullException(nameof(dispose));

            return new AnonymousAsyncDisposable(dispose, useFinalizerTrigger);
        }

        #endregion // Create

        #region AnonymousAsyncDisposable

        private sealed class AnonymousAsyncDisposable : IAsyncDisposable
        {
            private Func<ValueTask>? _dispose;

            public AnonymousAsyncDisposable(Func<ValueTask> dispose, bool useFinalizerTrigger = false)
            {
                _dispose = dispose;
                if (!useFinalizerTrigger)
                {
#pragma warning disable S3971 
                    GC.SuppressFinalize(this);
#pragma warning restore S3971 
                }
            }

            public async ValueTask DisposeAsync()
            {
                GC.SuppressFinalize(this);
                ValueTask task = Interlocked.Exchange(ref _dispose, null)?.Invoke() ?? default;
                await task;
            }

            ~AnonymousAsyncDisposable() => DisposeAsync().GetAwaiter().GetResult();
        }

        #endregion // AnonymousAsyncDisposable

        #region NopAsyncDisposable

        private sealed class NopAsyncDisposable : IAsyncDisposable
        {
            public ValueTask DisposeAsync() => default;
        }

        #endregion // NopAsyncDisposable
    }
}
