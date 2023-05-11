// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

using System.Threading;
using System.Threading.Tasks;

namespace Bnaya.Extensions.Common.Disposables
{
    public static class AsyncDisposable
    {
        public static IAsyncDisposable Nop { get; } = new NopAsyncDisposable();

        public static IAsyncDisposable Create(Func<ValueTask> dispose, bool useFinalizerTrigger = false)
        {
            if (dispose == null)
                throw new ArgumentNullException(nameof(dispose));

            return new AnonymousAsyncDisposable(dispose);
        }

        private sealed class AnonymousAsyncDisposable : IAsyncDisposable
        {
            private Func<ValueTask>? _dispose;

            public AnonymousAsyncDisposable(Func<ValueTask> dispose, bool useFinalizerTrigger = false)
            {
                if (!useFinalizerTrigger)
                    GC.SuppressFinalize(this);
                _dispose = dispose;
            }

            public async ValueTask DisposeAsync()
            {
                GC.SuppressFinalize(this);
                ValueTask task = Interlocked.Exchange(ref _dispose, null)?.Invoke() ?? default;
                await task;
            }

            ~AnonymousAsyncDisposable() => DisposeAsync().GetAwaiter().GetResult();
        }

        private sealed class NopAsyncDisposable : IAsyncDisposable
        {
            public ValueTask DisposeAsync() => default;
        }
    }
}
