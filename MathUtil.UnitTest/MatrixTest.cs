using System.Linq;
using MathUtil.Algebra;
using Xunit;

namespace MathUtil.UnitTest
{
    public class MatrixTest
    {
        [Fact]
        public void Test1()
        {
            var t = Enumerable.Range(0, 5).ToArray();

            var element1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var mat1 = new Matrix(3, 3, element1);
            Assert.Equal(mat1.Count, element1.Length);


            var element2 = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var mat2 = new Matrix(element2);
            var tempArr = mat2.ToArray();
            var strF = mat2.ToString();
            var matT = mat2.Transpose();
            var strS = matT.ToString();
        }
    }
}
