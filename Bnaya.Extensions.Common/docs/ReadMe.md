# Common extensions

- [String extensions](#String-extensions)
  - [ToCamel](#ToCamel)
  - [ToPascal](#ToPascal)
  - [ToDash](#ToDash)
  - [ToSCREAMING](#ToSCREAMING)
- [Collection extensions](#Collection-extensions)
	- [ToEnumerable](#ToEnumerable)
- [Disposables](#Disposables)
  - [Create](#Disposable.Create)
  - [Stack](#Disposable.CreateStack)

## String extensions

### ToCamel

> ``` cs
> [Theory]
> [InlineData("BnayaEshet", "bnayaEshet")]
> [InlineData("bnayaEshet", "bnayaEshet")]
> [InlineData("bnaya Eshet", "bnayaEshet")]
> [InlineData("bnaya-Eshet", "bnayaEshet")]
> [InlineData("bnaya_Eshet", "bnayaEshet")]
> [InlineData("bnaya_eshet", "bnayaEshet")]
> [InlineData("b1n2aya Eshet", "b1n2ayaEshet")]
> [InlineData("KNOW", "know")]
> [InlineData("KNOW_ME", "knowMe")]
> [InlineData("", "")]
> [InlineData(null, "")]
> public void String_ToCamelCase_Test_Succeed(string input, string expected)
> {
>     string result = input.ToCamel();
>     _outputHelper.WriteLine($"'{input}' = '{result}'");
>     Assert.Equal(expected, result);
> }
>```

### ToPascal

> ``` cs
> [Theory]
> [InlineData("BnayaEshet", "BnayaEshet")]
> [InlineData("bnayaEshet", "BnayaEshet")]
> [InlineData("bnaya Eshet", "BnayaEshet")]
> [InlineData("bnaya-Eshet", "BnayaEshet")]
> [InlineData("bnaya-eshet", "BnayaEshet")]
> [InlineData("bnaya_Eshet", "BnayaEshet")]
> [InlineData("Bnaya_eshet", "BnayaEshet")]
> [InlineData("bnaya_eshet", "BnayaEshet")]
> [InlineData("b1n2aya_eshet", "B1n2ayaEshet")]
> [InlineData("KNOW", "Know")]
> [InlineData("KNOW_ME", "KnowMe")]
> [InlineData("", "")]
> [InlineData(null, "")]
> public void String_ToPascalCase_Test_Succeed(string input, string expected)
> {
>     string result = input.ToPascal();
>     _outputHelper.WriteLine($"'{input}' = '{result}'");
>     Assert.Equal(expected, result);
> }
> ```

### ToDash

> ``` cs
> [Theory]
> [InlineData("BnayaEshet", "bnaya-eshet")]
> [InlineData("Bnaya_Eshet", "bnaya-eshet")]
> [InlineData("Bnaya_ESHET", "bnaya-eshet")]
> [InlineData("Bnaya1234Eshet", "bnaya1234-eshet")]
> [InlineData("Bnaya Eshet", "bnaya-eshet")]
> [InlineData(" Bnaya Eshet", "bnaya-eshet")]
> [InlineData("Bnaya Eshet ", "bnaya-eshet")]
> [InlineData("Bnaya  Eshet", "bnaya-eshet")]
> [InlineData("Bnay$a  Eshet", "bnay-a-eshet")]
> [InlineData("Bnaya$  Eshet", "bnaya-eshet")]
> [InlineData("Bnaya$Eshet", "bnaya-eshet")]
> [InlineData("Bnaya--Eshet", "bnaya-eshet")]
> [InlineData("Bnaya- -Eshet", "bnaya-eshet")]
> [InlineData("Bnaya__Eshet", "bnaya-eshet")]
> [InlineData("Bnaya_ _Eshet", "bnaya-eshet")]
> [InlineData("Bnaya _ _Eshet", "bnaya-eshet")]
> [InlineData("Bnaya_ _ Eshet", "bnaya-eshet")]
> [InlineData("", "")]
> [InlineData(null, "")]
> public void String_ToDash_Test_Succeed(string input, string expected)
> {
>     string result = input.ToDash();
>     _outputHelper.WriteLine($"'{input}' = '{result}'");
>     Assert.Equal(expected, result);
> }
> ``` 

### ToSCREAMING

> ``` cs
> [Theory]
> [InlineData("BnayaEshet", "BNAYA_ESHET")]
> [InlineData("Bnaya_Eshet", "BNAYA_ESHET")]
> [InlineData("Bnaya_ESHET", "BNAYA_ESHET")]
> [InlineData("Bnaya1234Eshet", "BNAYA1234_ESHET")]
> [InlineData("Bnaya Eshet", "BNAYA_ESHET")]
> [InlineData(" Bnaya Eshet", "BNAYA_ESHET")]
> [InlineData("Bnaya Eshet ", "BNAYA_ESHET")]
> [InlineData("Bnaya  Eshet", "BNAYA_ESHET")]
> [InlineData("Bnay$a  Eshet", "BNAY$A_ESHET")]
> [InlineData("Bnaya$  Eshet", "BNAYA$_ESHET")]
> [InlineData("Bnaya$Eshet", "BNAYA$_ESHET")]
> [InlineData("Bnaya__Eshet", "BNAYA_ESHET")]
> [InlineData("Bnaya_ _Eshet", "BNAYA_ESHET")]
> [InlineData("Bnaya _ _Eshet", "BNAYA_ESHET")]
> [InlineData("Bnaya_ _ Eshet", "BNAYA_ESHET")]
> [InlineData("", "")]
> [InlineData(null, "")]
> public void String_ToSCREAMING_Test_Succeed(string input, string expected)
> {
>     string result = input.ToSCREAMING();
>     _outputHelper.WriteLine($"'{input}' = '{result}'");
>     Assert.Equal(expected, result);
> }
> ```

## Collection extensions

### ToEnumerable

> ``` cs
> int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
> var r1 = 1.ToEnumerable(2, arr[2..]);
> var r2 = 1.ToEnumerable(2, 3, arr[3..]);
> var r3 = 1.ToEnumerable(2, 3, 4, arr[4..]);
> var r4 = arr[..2].ToEnumerable(3, 4, 5, 6, 7, 8, 9);
> 
> Assert.Equal(arr, r1);
> Assert.Equal(r1, r2);
> Assert.Equal(r2, r3);
> Assert.Equal(r3, r4);
> ```

## Disposables

Base on the Reactive Extensions disposable 

### Disposable.Create

> Create disposable on the fly with a delegate which will be invoked on disposal.
> 
> ```cs
> ILog logger = A.Fake<ILog>();
> using (var d = Disposable.Create(() => logger.Log("disposed")))
> {
>     A.CallTo(() => logger.Log(A<string>.Ignored))
>         .MustNotHaveHappened();
> }
> A.CallTo(() => logger.Log(A<string?>.Ignored))
>     .MustHaveHappenedOnceExactly();> 
> ```

### Disposable.CreateStack

> Disposable Stack pattern can be useful for maintain a context between method calls.  
> For example within a Visitor Pattern invocation.  
> Consider to declare Disposable.CreateStack at the class initialization.
> 
> ```cs
> IStackCancelable<int> d1;
> using (d1 = Disposable.CreateStack<int>(10))
> {
>     Assert.Equal(10, d1.State);
>     using (d1.Push(50))
>     {
>         Assert.Equal(50, d1.State);
>     }
>     using (d1.Push(2, (prv, inScope) => inScope * 2 + prv))
>     {
>         Assert.Equal(2, d1.State);
>     }
>     Assert.Equal(14, d1.State); // the state which was calculate when the scope ends
>     using (d1.Push(m => m * 2)) // calculate from current state
>     {
>         Assert.Equal(28, d1.State);
>     }
>     Assert.Equal(14, d1.State);
>     using (d1.Push(m => m * 2))
>     {
>         Assert.Equal(28, d1.State);
>         using (d1.Push(m => m * 2, (prv, inScope) => inScope + 1))
>         {
>             Assert.Equal(56, d1.State);
>         }
>         Assert.Equal(57, d1.State);
>     }
>     Assert.Equal(14, d1.State);
>     Assert.False(d1.IsDisposed);
> }
> Assert.True(d1.IsDisposed);
> ```

