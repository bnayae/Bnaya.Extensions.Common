// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

namespace Bnaya.Extensions.Common.Disposables;

/// <summary>
/// Stack of disposables
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <seealso cref="Bnaya.Extensions.Common.Disposables.IStackCancelable&lt;TState&gt;" />
internal sealed class StackDisposable<TState> : IStackCancelable<TState>
{
    private record StackItem(ICancelable<TState> Instance, Func<TState, TState, TState>? Restate = null);
    private readonly Stack<StackItem> _stack = new Stack<StackItem>();

    #region Ctor

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="state">The state.</param>
    /// <param name="dispose">The dispose.</param>
    public StackDisposable(TState state, Action<TState>? dispose)
    {
        var top = Disposable.Create(state, dispose);
        var item = new StackItem(top);
        _stack.Push(item);
    }

    #endregion // Ctor

    #region State

    /// <summary>
    /// Gets or Set the state.
    /// </summary>
    public TState State
    {
        get => Current.State;
        set => Current.State = value;
    }

    #endregion // State

    #region Push

    /// <summary>
    /// Pushes a disposable to the top of the stack.
    /// </summary>
    /// <param name="state">Get the current state as parameter and produce the initial state
    /// for the new disposable on the top of the stack.</param>
    /// <param name="dispose">Get the state of:
    /// - current disposal
    /// - previous disposal
    /// return the value which will be set to the previous disposal after it become the current again</param>
    /// <returns></returns>
    /// <exception cref="System.ObjectDisposedException">StackDisposable</exception>
    IDisposable IStackCancelable<TState>.Push(Func<TState, TState>? state, Func<TState, TState, TState>? dispose)
    {
        if (IsDisposed)
            throw new ObjectDisposedException(nameof(StackDisposable<TState>));

        TState curState = Current.State;
        TState newState = state == null ? curState : state.Invoke(curState);
        var newDisposable = Disposable.Create<TState>(newState);
        _stack.Push(new StackItem(newDisposable, dispose));

        return this;

    }

    /// <summary>
    /// Pushes a disposable to the top of the stack.
    /// </summary>
    /// <param name="state">init state.</param>
    /// <param name="dispose">
    /// Get the state of:
    /// - current disposal (after pop), the parent of the disposing one.
    /// - state of the disposing disposal (after pop)
    /// return the value which will be set to the previous disposal after it become the current again
    /// </param>
    /// <returns></returns>
    IDisposable IStackCancelable<TState>.Push(TState state, Func<TState, TState, TState>? dispose)
    {
        if (IsDisposed)
            throw new ObjectDisposedException(nameof(StackDisposable<TState>));

        TState curState = Current.State;
        var newDisposable = Disposable.Create<TState>(state);
        _stack.Push(new StackItem(newDisposable, dispose));

        return this;

    }

    #endregion // Push

    #region IsDisposed

    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    public bool IsDisposed => _stack.Count == 0;

    #endregion // IsDisposed

    #region Current

    /// <summary>
    /// Sets the current.
    /// </summary>
    private ICancelable<TState> Current => _stack.Peek().Instance;

    #endregion // Current

    #region Dispose Pattern

    /// <summary>
    /// Calls the disposal action if and only if the current instance hasn't been disposed yet.
    /// </summary>
    public void Dispose()
    {
        var prevItem = _stack.Pop();
        var prev = prevItem.Instance;
        if (!IsDisposed && prevItem.Restate != null)
        {
            var cur = Current;
            var state = prevItem.Restate(cur.State, prev.State);
            cur.State = state;
        }
        prev.Dispose();
    }

    #endregion // Dispose Pattern
}
