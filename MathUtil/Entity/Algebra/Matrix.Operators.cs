using System;

namespace MathUtil.Algebra
{
    public partial class Matrix
    {
        public static Matrix Negate(Matrix matrix)
        {
            var result = new Matrix(matrix._rowCount, matrix._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, -1d * matrix.Get(i));
            }
            return result;
        }
        public static Matrix Add(Matrix matrix, double scalar)
        {
            var result = new Matrix(matrix._rowCount, matrix._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, scalar + matrix.Get(i));
            }
            return result;
        }
        public static Matrix Add(double scalar, Matrix matrix)
        {
            return Matrix.Add(matrix, scalar);
        }
        public static Matrix Add(Matrix left, Matrix right)
        {
            CheckSameDimension(left, right);
            var result = new Matrix(left._rowCount, left._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, left.Get(i) + right.Get(i));
            }
            return result;
        }
        public static Matrix Subtract(Matrix matrix, double scalar)
        {
            var result = new Matrix(matrix._rowCount, matrix._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, matrix.Get(i) - scalar);
            }
            return result;
        }
        public static Matrix Subtract(double scalar, Matrix matrix)
        {
            var result = new Matrix(matrix._rowCount, matrix._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, scalar - matrix.Get(i));
            }
            return result;
        }
        public static Matrix Subtract(Matrix left, Matrix right)
        {
            CheckSameDimension(left, right);
            var result = new Matrix(left._rowCount, left._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, left.Get(i) - right.Get(i));
            }
            return result;
        }
        public static Matrix Multiply(Matrix matrix, double scalar)
        {
            var result = new Matrix(matrix._rowCount, matrix._colCount, false);
            for (int i = 0; i < result._total; i++)
            {
                result.Set(i, scalar * matrix.Get(i));
            }
            return result;
        }
        public static Matrix Multiply(double scalar, Matrix matrix)
        {
            return Matrix.Multiply(matrix, scalar);
        }
        public static Matrix Multiply(Matrix left, Matrix right)
        {
            CheckMultipliable(left, right);
            var result = new Matrix(left._rowCount, right._colCount);

            return result;
        }
        public static Vector Multiply(Matrix matrix, Vector vector)
        {
            CheckMultipliable(matrix, vector);
            var result = new Vector(vector.Count);
            for (int i = 0; i < matrix._rowCount; i++)
            {
                var temp = 0d;
                for (int j = 0; j < matrix._colCount; j++)
                {
                    temp += matrix.Get(i, j) * vector.Get(j);
                }
                result.Set(i, temp);
            }
            return result;
        }
        public static Vector Multiply(Vector vector, Matrix matrix)
        {
            CheckMultipliable(vector, matrix);
            var result = new Vector(vector.Count);
            for (int i = 0; i < matrix._colCount; i++)
            {
                var temp = 0d;
                for (int j = 0; j < matrix._rowCount; j++)
                {
                    temp += vector.Get(j) * matrix.Get(j, i);
                }
                result.Set(i, temp);
            }
            return result;
        }
        public static Matrix Divide(Matrix matrix, double scalar)
        {
            return Matrix.Multiply(matrix, 1d / scalar);
        }
        public static Matrix Divide(double scalar, Matrix matrix)
        {
            throw new NotImplementedException();
        }
        public static Matrix Divide(Matrix left, Matrix right)
        {
            throw new NotImplementedException();
        }
        public static Matrix TransposeMultiply(Matrix matrix, Matrix other)
        {
            throw new NotImplementedException();
        }
        public static Matrix TransposeMultiply(Matrix matrix, Vector other)
        {
            throw new NotImplementedException();
        }

        #region operator
        public static Matrix operator +(Matrix matrix, double scalar)
        {
            return Matrix.Add(matrix, scalar);
        }
        public static Matrix operator +(double scalar, Matrix matrix)
        {
            return Matrix.Add(scalar, matrix);
        }
        public static Matrix operator +(Matrix left, Matrix right)
        {
            return Matrix.Add(left, right);
        }
        public static Matrix operator -(Matrix matrix)
        {
            return Matrix.Negate(matrix);
        }
        public static Matrix operator -(Matrix matrix, double scalar)
        {
            return Matrix.Subtract(matrix, scalar);
        }
        public static Matrix operator -(double scalar, Matrix matrix)
        {
            return Matrix.Subtract(scalar, matrix);
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            return Matrix.Subtract(left, right);
        }
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            return Matrix.Multiply(matrix, scalar);
        }
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return Matrix.Multiply(scalar, matrix);
        }
        public static Matrix operator *(Matrix left, Matrix right)
        {
            return Matrix.Multiply(left, right);
        }
        public static Vector operator *(Matrix matrix, Vector vector)
        {
            return Matrix.Multiply(matrix, vector);
        }
        public static Vector operator *(Vector vector, Matrix matrix)
        {
            return Matrix.Multiply(vector, matrix);
        }
        public static Matrix operator /(Matrix matrix, double scalar)
        {
            return Matrix.Divide(matrix, scalar);
        }
        public static Matrix operator /(double scalar, Matrix matrix)
        {
            return Matrix.Divide(scalar, matrix);
        }
        #endregion
    }
}
