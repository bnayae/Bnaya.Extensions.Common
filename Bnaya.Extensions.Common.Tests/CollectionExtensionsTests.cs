
using Xunit;

namespace Bnaya.Extensions.Common.Tests
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void ToEnumerable_Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var r1 = 1.ToEnumerable(2, arr[2..]);
            var r2 = 1.ToEnumerable(2, 3, arr[3..]);
            var r3 = 1.ToEnumerable(2, 3, 4, arr[4..]);
            var r4 = arr[..2].ToEnumerable(3, 4, 5, 6, 7, 8, 9);
            var r5 = 1.ToEnumerable(2, arr[2..] as IEnumerable<int>);
            var r6 = 1.ToEnumerable(2, 3, arr[3..] as IEnumerable<int>);
            var r7 = 1.ToEnumerable(2, 3, 4, arr[4..] as IEnumerable<int>);
            var r8 = 1.ToEnumerable((IEnumerable<int>)arr[1..]);

            Assert.Equal(arr, r1);
            Assert.Equal(r1, r2);
            Assert.Equal(r2, r3);
            Assert.Equal(r3, r4);
            Assert.Equal(r4, r5);
            Assert.Equal(r5, r6);
            Assert.Equal(r5, r6);
            Assert.Equal(r7, r8);
        }
    }
}
