
using Xunit;
using Xunit.Abstractions;

namespace Bnaya.Extensions.Common.Tests
{
    public class StringExtensionsTests
    {
        private readonly ITestOutputHelper _outputHelper;

        #region Ctor

        public StringExtensionsTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        #endregion Ctor

        #region String_ToSCREAMING_Test_Succeed

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

        #endregion // String_ToSCREAMING_Test_Succeed

        #region String_ToDash_Test_Succeed

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

        #endregion // String_ToDash_Test_Succeed

        #region String_ToPascalCase_Test_Succeed

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
        [InlineData("KNOW", "Know")]
        [InlineData("KNOW_ME", "KnowMe")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void String_ToPascalCase_Test_Succeed(string input, string expected)
        {
            string result = input.ToPascal();
            _outputHelper.WriteLine($"'{input}' = '{result}'");
            Assert.Equal(expected, result);
        }

        #endregion // String_ToPascalCase_Test_Succeed

        #region String_ToCamelCase_Test_Succeed

        [Theory]
        [InlineData(" BnayaEshet", "bnayaEshet")]
        [InlineData("BnayaEshet", "bnayaEshet")]
        [InlineData("bnayaEshet", "bnayaEshet")]
        [InlineData(" bnayaEshet", "bnayaEshet")]
        [InlineData("bnaya Eshet", "bnayaEshet")]
        [InlineData("bnaya-Eshet", "bnayaEshet")]
        [InlineData("bnaya_Eshet", "bnayaEshet")]
        [InlineData("bnaya_eshet", "bnayaEshet")]
        [InlineData("b1n2aya Eshet", "b1n2ayaEshet")]
        [InlineData("KNOW", "know")]
        [InlineData("KNOW_ME", "knowMe")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void String_ToCamelCase_Test_Succeed(string input, string expected)
        {
            string result = input.ToCamel();
            _outputHelper.WriteLine($"'{input}' = '{result}'");
            Assert.Equal(expected, result);
        }

        #endregion // String_ToCamelCase_Test_Succeed
    }
}
