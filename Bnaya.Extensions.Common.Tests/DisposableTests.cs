using System.Disposables;

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

        #region Disposable_Create_Test

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

        #endregion // Disposable_Create_Test

        #region Disposable_Empty_Test

        [Fact]
#pragma warning disable S2699 // Tests should include assertions
        public void Disposable_Empty_Test()
        {
            using (var d = Disposable.Empty)
            {
                // do nothing
            }
        }
#pragma warning restore S2699 // Tests should include assertions

        #endregion // Disposable_Empty_Test

        #region DisposableStack_Test

        [Fact]
        public void DisposableStack_Test()
        {
            StackDisposable<int> d1;
            using (d1 = Disposable.CreateStack<int>(10))
            {
                _outputHelper.WriteLine(d1.ToString());
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
                    Assert.Equal(28, d1.State);
                }
                Assert.Equal(14, d1.State);
                using (var state = d1.Push(m => m * 2))
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

        #endregion // DisposableStack_Test

        #region DisposableStackCollection_Test

        [Fact]
        public void DisposableStackCollection_Test()
        {
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
                    using (var state1 = stackCollection.Add(5, 6, 7))
                    {
                        Assert.True(state1.SequenceEqual(10.ToEnumerable(30, 5, 6, 7)));
                    }
                    Assert.True(stackCollection.SequenceEqual(10.ToEnumerable(30)));
                }
                Assert.True(stackCollection.SequenceEqual(10.ToEnumerable()));
                Assert.False(stackCollection.IsDisposed);
            }
            Assert.True(stackCollection.IsDisposed);
        }

        #endregion // DisposableStackCollection_Test
    }
}
