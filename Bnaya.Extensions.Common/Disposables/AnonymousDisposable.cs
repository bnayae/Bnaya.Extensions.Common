// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Concurrent;

namespace Bnaya.Extensions.Common.Disposables;


/// <summary>
/// Represents an Action-based disposable.
/// </summary>
internal sealed class AnonymousDisposable : ICancelable
{
    private volatile Action? _dispose;

    /// <summary>
    /// Constructs a new disposable with the given action used for disposal.
    /// </summary>
    /// <param name="dispose">Disposal action which will be run upon calling Dispose.</param>
    /// <param name="useFinalizerTrigger">if set to <c>true</c> [use finalizer trigger].</param>
    public AnonymousDisposable(Action dispose, bool useFinalizerTrigger = false)
    {
        if (!useFinalizerTrigger)
            GC.SuppressFinalize(this);
        _dispose = dispose;
    }

    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    public bool IsDisposed => _dispose == null;

    ~AnonymousDisposable() => Dispose();

    /// <summary>
    /// Calls the disposal action if and only if the current instance hasn't been disposed yet.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Interlocked.Exchange(ref _dispose, null)?.Invoke();
    }
}

/// <summary>
/// Represents a Action-based disposable that can hold onto some state.
/// </summary>
internal sealed class AnonymousDisposable<TState> : ICancelable<TState>
{
    public TState State { get; set; }
    private volatile Action<TState>? _dispose;

    #region Ctor

    /// <summary>
    /// Constructs a new disposable with the given action used for disposal.
    /// </summary>
    /// <param name="state">The state to be passed to the disposal action.</param>
    /// <param name="dispose">Disposal action which will be run upon calling Dispose.</param>
    /// <param name="useFinalizerTrigger">if set to <c>true</c> [use finalizer trigger].</param>
    public AnonymousDisposable(TState state, Action<TState>? dispose, bool useFinalizerTrigger = false)
    {
        if (!useFinalizerTrigger)
            GC.SuppressFinalize(this);
        State = state;
        _dispose = dispose;
    }

    #endregion // Ctor

    #region IsDisposed

    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    public bool IsDisposed => _dispose == null;

    #endregion // IsDisposed

    #region Dispose Pattern

    /// <summary>
    /// Finalizes an instance of the <see cref="AnonymousDisposable{TState}"/> class.
    /// </summary>
    ~AnonymousDisposable() => Dispose();

    /// <summary>
    /// Calls the disposal action if and only if the current instance hasn't been disposed yet.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Interlocked.Exchange(ref _dispose, null)?.Invoke(State);
        State = default!;
    }

    #endregion // Dispose Pattern
}
