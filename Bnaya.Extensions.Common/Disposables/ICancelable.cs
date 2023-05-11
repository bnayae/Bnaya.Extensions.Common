// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

namespace Bnaya.Extensions.Common.Disposables;

/// <summary>
/// Disposable resource with disposal state tracking.
/// </summary>
public interface ICancelable : IDisposable
{
    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    bool IsDisposed { get; }
}

/// <summary>
/// Disposable resource with disposal state tracking.
/// </summary>
public interface ICancelable<TState> : ICancelable
{
    /// <summary>
    /// Gets or Set the state.
    /// </summary>
    TState State { get; set; }
}