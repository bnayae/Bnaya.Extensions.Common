// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

#pragma warning disable S3881 // "IDisposable" should be implemented correctly

namespace Bnaya.Extensions.Common.Disposables;

/// <summary>
/// Cancelable collection
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TItem">The type of the item.</typeparam>
/// <seealso cref="Bnaya.Extensions.Common.Disposables.CancelableBase&lt;TState&gt;" />
/// <seealso cref="System.Collections.Generic.IEnumerable&lt;TItem&gt;" />
public abstract class CancelableCollectionBase<TState, TItem> : CancelableBase<TState>,
    IEnumerable<TItem>
    where TState : IEnumerable<TItem>
{
    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (var item in State)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
