
using Bnaya.Extensions.Common.Disposables;

using Xunit;

namespace Bnaya.Extensions.Common.Tests
{
    public class DisposableTests
    {
        [Fact]
        public void DisposableStack_Test()
        {
            IStackCancelable<int> d1;
            using (d1 = Disposable.CreateStack(0))
            {
                Assert.Equal(0, d1.State);
                using (d1.Push(1, (cur, disposing) => disposing * 2 + cur))
                {
                    Assert.Equal(1, d1.State);
                }
                Assert.Equal(2, d1.State);
                using (d1.Push(m => m * 2))
                {
                    Assert.Equal(4, d1.State);
                }
                Assert.Equal(2, d1.State);
                using (d1.Push(m => m * 2))
                {
                    Assert.Equal(4, d1.State);
                    using (d1.Push(m => m * 2, (cur, disposing) => disposing + cur))
                    {
                        Assert.Equal(8, d1.State);
                    }
                    Assert.Equal(12, d1.State);
                }
                Assert.Equal(2, d1.State);
            }
            Assert.True(d1.IsDisposed);
        }
    }
}
