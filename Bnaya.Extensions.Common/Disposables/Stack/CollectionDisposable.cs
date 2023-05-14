// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Immutable;

using Bnaya.Extensions.Common.Disposables;

namespace System.Disposables;

/// <summary>
/// Build immutable list with correlate to the Stack
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <remarks>
/// Not thread safe: won't work well under multi thread environment (without proper synchronization).
/// </remarks>
public sealed class CollectionDisposable<TState> :
    CancelableCollectionBase<IImmutableList<TState>, TState>,
    IEnumerable<TState>
{
    private readonly StackDisposable<IImmutableList<TState>> _stack;
    private readonly Action? _onDisposal;

    #region Ctor

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="onDisposal">The on disposal.</param>
    public CollectionDisposable(Action? onDisposal)
    {
        _onDisposal = onDisposal;
        _stack = Disposable.CreateStack<IImmutableList<TState>>(
                                                    ImmutableList<TState>.Empty,
                                                    _ => _onDisposal?.Invoke());
    }

    #endregion // Ctor

    #region State

    /// <summary>
    /// Gets or Set the state.
    /// </summary>
    public override IImmutableList<TState> State { get => _stack.State; internal set => _stack.State = value; }

    #endregion // State

    #region Push

    /// <summary>
    /// Adds an item to the list under the current stack context.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="more">The more.</param>
    /// <returns></returns>
    public CancelableCollectionBase<IImmutableList<TState>, TState> Add(TState item, params TState[] more)
    {
        IImmutableList<TState> newState = _stack.State.Add(item);
        foreach (var m in more ?? Array.Empty<TState>())
        {
            newState = newState.Add(m);
        }
        _stack.Push(newState);
        return this;
    }

    #endregion // Push

    #region IsDisposed

    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    public override bool IsDisposed => _stack.IsDisposed;

    #endregion // IsDisposed

    #region Dispose Pattern

    /// <summary>
    /// Calls the disposal action if and only if the current instance hasn't been disposed yet.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        _stack.Dispose();
    }

    /// <summary>
    /// Finalizes this instance.
    /// </summary>
    ~CollectionDisposable()
    {
        _stack.Dispose();
    }

    #endregion // Dispose Pattern

    #region override ToString

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => string.Join(',', _stack.State);

    #endregion // override ToString
}
