# Bnaya.Extensions.Common

[![Build & Deploy NuGet](https://github.com/bnayae/Bnaya.Extensions.Common/actions/workflows/Deploy.yml/badge.svg)](https://github.com/bnayae/Bnaya.Extensions.Common/actions/workflows/Deploy.yml)  

[![NuGet](https://img.shields.io/nuget/v/Bnaya.Extensions.Common.svg)](https://www.nuget.org/packages/Bnaya.Extensions.Common/)

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
- [Json extenssions](https://github.com/bnayae/Json.Extensions)
- [Async extensions](https://github.com/bnayae/Bnaya.CSharp.AsyncExtensions)

## Examples

### ToCamelCase

> ```cs
> [Theory]
> [InlineData("BnayaEshet", "bnayaEshet")]
> [InlineData("bnayaEshet", "bnayaEshet")]
> [InlineData("bnaya Eshet", "bnayaEshet")]
> [InlineData("bnaya-Eshet", "bnayaEshet")]
> [InlineData("bnaya_Eshet", "bnayaEshet")]
> [InlineData("bnaya_eshet", "bnayaEshet")]
> [InlineData("b1n2aya Eshet", "b1n2ayaEshet")]
> [InlineData("", "")]
> [InlineData(null, "")]
> public void String_ToCamelCase_Test_Succeed(string input, string expected)
> {
>     string result = input.ToCamelCase();
>     _outputHelper.WriteLine($"'{input}' = '{result}'");
>     Assert.Equal(expected, result);
> }
> ```

### ToPascalCase

> ```cs
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
> [InlineData("", "")]
> [InlineData(null, "")]
> public void String_ToPascalCase_Test_Succeed(string input, string expected)
> {
>     string result = input.ToPascalCase();
>     _outputHelper.WriteLine($"'{input}' = '{result}'");
>     Assert.Equal(expected, result);
> }
> ```

### ToSCREAMING

> ```cs
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

### ToDash
> 
> ```cs
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


### ToEnumerable

> ``` cs
> int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
> 
> var r1 = 1.ToEnumerable(2, arr[2..]);
> Assert.Equal(arr, r1);
> 
> var r2 = 1.ToEnumerable(2, 3, arr[3..]);
> Assert.Equal(arr, r2);
> 
> var r3 = 1.ToEnumerable(2, 3, 4, arr[4..]);
> Assert.Equal(arr, r3);
> 
> var r4 = arr[..2].ToEnumerable(3, 4, 5, 6, 7, 8, 9);
> Assert.Equal(arr, r4);
> ```
