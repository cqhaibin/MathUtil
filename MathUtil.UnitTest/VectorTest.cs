using MathUtil.Algebra;
using Xunit;

namespace MathUtil.UnitTest
{
    public class VectorTest
    {
        [Fact]
        public void Test1()
        {
            var element = new double[] { 1, 3, 5, 7 };
            var vec = new Vector(element);
            vec.Clear();
        }
    }
}
