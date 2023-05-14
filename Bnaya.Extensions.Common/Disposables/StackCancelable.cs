// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

namespace Bnaya.Extensions.Common.Disposables;

/// <summary>
/// Disposable stack capable of pushing new disposable to the top of the stack 
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
public abstract class StackCancelable<TState>: CancelableBase<TState> 
{
    /// <summary>
    /// Pushes a disposable to the top of the stack.
    /// </summary>
    /// <param name="state">
    /// Get the current state as parameter and produce the initial state
    /// for the new disposable on the top of the stack.
    /// </param>
    /// <param name="dispose">
    /// Get the state of:
    /// - current disposal
    /// - disposal target
    /// return the value which will be set to the previous disposal after it become the current again
    /// </param>
    /// <returns></returns>
    public abstract CancelableBase<TState> Push(
        Func<TState, TState>? state = null, 
        Func<TState, TState, TState>? dispose = null);

    /// <summary>
    /// Pushes a disposable to the top of the stack.
    /// </summary>
    /// <param name="state">
    /// init state.
    /// </param>
    /// <param name="dispose">
    /// Get the state of:
    /// - current disposal (after pop), the parent of the disposing one.
    /// - state of the disposing disposal (after pop)
    /// return the value which will be set to the previous disposal after it become the current again
    /// </param>
    /// <returns></returns>
    public abstract CancelableBase<TState> Push(
        TState state, 
        Func<TState, TState, TState>? dispose = null);
}