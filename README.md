# Bnaya.Extensions.Common

[![Build & Deploy NuGet](https://github.com/bnayae/Bnaya.Extensions.Common/actions/workflows/Deploy.yml/badge.svg)](https://github.com/bnayae/Bnaya.Extensions.Common/actions/workflows/Deploy.yml)  

[![NuGet](https://img.shields.io/nuget/v/Bnaya.Extensions.Common.svg)](https://www.nuget.org/packages/Bnaya.Extensions.Common/)  

[![codecov](https://codecov.io/gh/bnayae/Bnaya.Extensions.Common/branch/main/graph/badge.svg?token=W85TL1QVQB)](https://codecov.io/gh/bnayae/Bnaya.Extensions.Common)  


Set of basic extensions. 

## String Extensions

- [ToCamelCase](#ToCamelCase) 
- [ToPascalCase](#ToPascalCase)
- [ToSCREAMING](ToSCREAMING)
- [ToDash](#ToDash)

## Collection Extensions
- [ToEnumerable](#ToEnumerable): Converts any thing to IEnumerable (yield)

## Looking for other extensions?
Check the following
- [Bnaya.Extensions.Json](https://github.com/bnayae/Bnaya.Extensions.Json)
- [Async extensions](https://github.com/bnayae/Bnaya.CSharp.AsyncExtensions)

## Examples

### ToCamelCase

``` cs
"Hello World".ToCamelCase(); // helloWorld
```

<details><summary>Sample</summary>
<blockquote>

```cs
[Theory]
[InlineData("BnayaEshet", "bnayaEshet")]
[InlineData("bnayaEshet", "bnayaEshet")]
[InlineData("bnaya Eshet", "bnayaEshet")]
[InlineData("bnaya-Eshet", "bnayaEshet")]
[InlineData("bnaya_Eshet", "bnayaEshet")]
[InlineData("bnaya_eshet", "bnayaEshet")]
[InlineData("b1n2aya Eshet", "b1n2ayaEshet")]
[InlineData("", "")]
[InlineData(null, "")]
public void String_ToCamelCase_Test_Succeed(string input, string expected)
{
    string result = input.ToCamelCase();
    _outputHelper.WriteLine($"'{input}' = '{result}'");
    Assert.Equal(expected, result);
}
```

</blockquote>
</details>

### ToPascalCase

``` cs
"hello World".ToCamelCase(); // HelloWorld
```

<details><summary>Sample</summary>
<blockquote>

```cs
[Theory]
[InlineData("BnayaEshet", "BnayaEshet")]
[InlineData("bnayaEshet", "BnayaEshet")]
[InlineData("bnaya Eshet", "BnayaEshet")]
[InlineData("bnaya-Eshet", "BnayaEshet")]
[InlineData("bnaya-eshet", "BnayaEshet")]
[InlineData("bnaya_Eshet", "BnayaEshet")]
[InlineData("Bnaya_eshet", "BnayaEshet")]
[InlineData("bnaya_eshet", "BnayaEshet")]
[InlineData("b1n2aya_eshet", "B1n2ayaEshet")]
[InlineData("", "")]
[InlineData(null, "")]
public void String_ToPascalCase_Test_Succeed(string input, string expected)
{
    string result = input.ToPascalCase();
    _outputHelper.WriteLine($"'{input}' = '{result}'");
    Assert.Equal(expected, result);
}
```

</blockquote>
</details>

### ToSCREAMING

``` cs
"helloWorld".ToCamelCase(); // HELLO_WORLD
```

<details><summary>Sample</summary>
<blockquote>

```cs
[Theory]
[InlineData("BnayaEshet", "BNAYA_ESHET")]
[InlineData("Bnaya_Eshet", "BNAYA_ESHET")]
[InlineData("Bnaya_ESHET", "BNAYA_ESHET")]
[InlineData("Bnaya1234Eshet", "BNAYA1234_ESHET")]
[InlineData("Bnaya Eshet", "BNAYA_ESHET")]
[InlineData(" Bnaya Eshet", "BNAYA_ESHET")]
[InlineData("Bnaya Eshet ", "BNAYA_ESHET")]
[InlineData("Bnaya  Eshet", "BNAYA_ESHET")]
[InlineData("Bnay$a  Eshet", "BNAY$A_ESHET")]
[InlineData("Bnaya$  Eshet", "BNAYA$_ESHET")]
[InlineData("Bnaya$Eshet", "BNAYA$_ESHET")]
[InlineData("Bnaya__Eshet", "BNAYA_ESHET")]
[InlineData("Bnaya_ _Eshet", "BNAYA_ESHET")]
[InlineData("Bnaya _ _Eshet", "BNAYA_ESHET")]
[InlineData("Bnaya_ _ Eshet", "BNAYA_ESHET")]
[InlineData("", "")]
[InlineData(null, "")]
public void String_ToSCREAMING_Test_Succeed(string input, string expected)
{
    string result = input.ToSCREAMING();
    _outputHelper.WriteLine($"'{input}' = '{result}'");
    Assert.Equal(expected, result);
}
```

</blockquote>
</details>

### ToDash

``` cs
"Hello World".ToCamelCase(); // hello-world
```

<details><summary>Sample</summary>
<blockquote>

```cs
[Theory]
[InlineData("BnayaEshet", "bnaya-eshet")]
[InlineData("Bnaya_Eshet", "bnaya-eshet")]
[InlineData("Bnaya_ESHET", "bnaya-eshet")]
[InlineData("Bnaya1234Eshet", "bnaya1234-eshet")]
[InlineData("Bnaya Eshet", "bnaya-eshet")]
[InlineData(" Bnaya Eshet", "bnaya-eshet")]
[InlineData("Bnaya Eshet ", "bnaya-eshet")]
[InlineData("Bnaya  Eshet", "bnaya-eshet")]
[InlineData("Bnay$a  Eshet", "bnay-a-eshet")]
[InlineData("Bnaya$  Eshet", "bnaya-eshet")]
[InlineData("Bnaya$Eshet", "bnaya-eshet")]
[InlineData("Bnaya--Eshet", "bnaya-eshet")]
[InlineData("Bnaya- -Eshet", "bnaya-eshet")]
[InlineData("Bnaya__Eshet", "bnaya-eshet")]
[InlineData("Bnaya_ _Eshet", "bnaya-eshet")]
[InlineData("Bnaya _ _Eshet", "bnaya-eshet")]
[InlineData("Bnaya_ _ Eshet", "bnaya-eshet")]
[InlineData("", "")]
[InlineData(null, "")]
public void String_ToDash_Test_Succeed(string input, string expected)
{
    string result = input.ToDash();
    _outputHelper.WriteLine($"'{input}' = '{result}'");
    Assert.Equal(expected, result);
}
```

</blockquote>
</details>


## ToEnumerable

<details open><summary>Sample</summary>
<blockquote>

``` cs
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var r1 = 1.ToEnumerable(2, arr[2..]);
Assert.Equal(arr, r1);

var r2 = 1.ToEnumerable(2, 3, arr[3..]);
Assert.Equal(arr, r2);

var r3 = 1.ToEnumerable(2, 3, 4, arr[4..]);
Assert.Equal(arr, r3);

var r4 = arr[..2].ToEnumerable(3, 4, 5, 6, 7, 8, 9);
Assert.Equal(arr, r4);
```

</blockquote>
</details>

## Disposables

Disposable pattern (based on Reactive Extensions)

### Disposable.Empty

Disposable which do noting on disposal.  
Useful when the needs for disposable is conditional (under the using pattern).

<details open><summary>Sample</summary>
<blockquote>

``` cs
using var dsp = factory?.GetDisposable() ?? isposable.Empty;
``` 

</blockquote>
</details>

### Disposable.Create

Creates a disposable object that invokes the specified action when disposed.

``` cs
using var d = Disposable.Create(() => logger.Log("disposed"));
```

<details><summary>Sample</summary>
<blockquote>


``` cs
ILog logger = A.Fake<ILog>();
using (var d = Disposable.Create(() => logger.Log("disposed")))
{
    A.CallTo(() => logger.Log(A<string>.Ignored))
        .MustNotHaveHappened();
}
A.CallTo(() => logger.Log(A<string?>.Ignored))
    .MustHaveHappenedOnceExactly();
``` 

</blockquote>
</details>

### Disposable.CreateStack

Maintain a scoped state (which can affect parent state on exit by a custom logic).  

Can be useful to maintain state with in a Visitor pattern (or functional programming).

<details><summary>Sample</summary>
<blockquote>

``` cs
StackCancelable<int> d1;
using (d1 = Disposable.CreateStack<int>(10))
{
    Assert.Equal(10, d1.State);
    using (var state = d1.Push(50))
    {
        Assert.Equal(50, d1.State);
        Assert.Equal(50, state.State);
        int i = state;
        Assert.Equal(50, i);
    }
    using (var state = d1.Push(2, (prv, inScope) => inScope * 2 + prv))
    {
        Assert.Equal(2, state);
        Assert.Equal(2, d1.State);
    }
    Assert.Equal(14, d1.State); // the state which was calculate when the scope ends
    using (var state = d1.Push(m => m * 2)) // calculate from current state
    {
        Assert.Equal(28, state);
    }
    Assert.Equal(14, d1.State);
    using (var state = d1.Push(m => m * 2))
    {
        Assert.Equal(28, d1.State);
        using (var state1 = d1.Push(m => m * 2, (prv, inScope) => inScope + 1))
        {
            Assert.Equal(56, state1);
        }
        Assert.Equal(57, d1.State);
    }
    Assert.Equal(14, d1.State);
    Assert.False(d1.IsDisposed);
}
Assert.True(d1.IsDisposed);
```

</blockquote>
</details>

### Disposable.CreateCollection

Creates a collection builder, which aware of the stack context.  
It'll remove items from the collection on stack frame disposal

<details><summary>Sample</summary>
<blockquote>

``` cs
CollectionDisposable<int> stackCollection;
using (stackCollection = Disposable.CreateCollection<int>())
using (var root = stackCollection.Add(10))
{
    _outputHelper.WriteLine(stackCollection.ToString());
    _outputHelper.WriteLine(root.ToString());
    Assert.True(10.ToEnumerable().SequenceEqual(stackCollection.State));
    using (var state = stackCollection.Add(50))
    {
        Assert.True(state.SequenceEqual(10.ToEnumerable(50)));
    }
    using (var state = stackCollection.Add(2))
    {
        Assert.True(state.SequenceEqual(10.ToEnumerable(2)));
    }
    Assert.True(stackCollection.SequenceEqual(10.ToEnumerable()));
    using (var state = stackCollection.Add(30))
    {
        Assert.True(state.SequenceEqual(10.ToEnumerable(30)));
        using (var state1 = stackCollection.Add(5,6, 7))
        {
            Assert.True(state1.SequenceEqual(10.ToEnumerable(30, 5, 6, 7)));
        }
        Assert.True(stackCollection.SequenceEqual(10.ToEnumerable(30)));
    }
    Assert.True(stackCollection.SequenceEqual(10.ToEnumerable()));
    Assert.False(stackCollection.IsDisposed);
}
Assert.True(stackCollection.IsDisposed);
```

</blockquote>
</details>
