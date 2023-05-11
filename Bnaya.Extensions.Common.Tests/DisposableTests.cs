
using Bnaya.Extensions.Common.Disposables;

using FakeItEasy;

using Xunit;
using Xunit.Abstractions;

namespace Bnaya.Extensions.Common.Tests
{
    public interface ILog
    {
        void Log(string message);
    }

    public class DisposableTests
    {
        private readonly ITestOutputHelper _outputHelper;

        #region Ctor

        public DisposableTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        #endregion Ctor

        [Fact]
        public void Disposable_Create_Test()
        {
            ILog logger = A.Fake<ILog>();
            using (var d = Disposable.Create(() => logger.Log("disposed")))
            {
                A.CallTo(() => logger.Log(A<string>.Ignored))
                    .MustNotHaveHappened();
            }
            A.CallTo(() => logger.Log(A<string?>.Ignored))
                .MustHaveHappenedOnceExactly();
        }


        [Fact]
        public void Disposable_Empty_Test()
        {
            using (var d = Disposable.Empty)
            {
                // do nothing
            }
        }

        [Fact]
        public void DisposableStack_Test()
        {
            IStackCancelable<int> d1;
            using (d1 = Disposable.CreateStack<int>(10))
            {
                Assert.Equal(10, d1.State);
                using (d1.Push(50))
                {
                    Assert.Equal(50, d1.State);
                }
                using (d1.Push(2, (prv, inScope) => inScope * 2 + prv))
                {
                    Assert.Equal(2, d1.State);
                }
                Assert.Equal(14, d1.State); // the state which was calculate when the scope ends
                using (d1.Push(m => m * 2)) // calculate from current state
                {
                    Assert.Equal(28, d1.State);
                }
                Assert.Equal(14, d1.State);
                using (d1.Push(m => m * 2))
                {
                    Assert.Equal(28, d1.State);
                    using (d1.Push(m => m * 2, (prv, inScope) => inScope + 1))
                    {
                        Assert.Equal(56, d1.State);
                    }
                    Assert.Equal(57, d1.State);
                }
                Assert.Equal(14, d1.State);
                Assert.False(d1.IsDisposed);
            }
            Assert.True(d1.IsDisposed);
        }
    }
}
