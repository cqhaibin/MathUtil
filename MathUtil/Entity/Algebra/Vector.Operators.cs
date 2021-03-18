namespace MathUtil.Algebra
{
    public partial class Vector
    {
        public static Vector Negate(Vector vector)
        {
            var result = new double[vector._total];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = vector.Get(i);
            }
            return result;
        }
        public static Vector Add(Vector left, Vector right)
        {
            CheckSameDimension(left, right);
            var result = new double[left._total];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left.Get(i) + right.Get(i);
            }
            return result;
        }
        public static Vector Subtract(Vector left, Vector right)
        {
            CheckSameDimension(left, right);
            var result = new double[left._total];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left.Get(i) - right.Get(i);
            }
            return result;
        }
        public static Vector Multiply(Vector vector, double scalar)
        {
            var result = new double[vector._total];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = vector.Get(i) + scalar;
            }
            return result;
        }
        public static Vector Multiply(double scalar, Vector vector)
        {
            return Vector.Multiply(vector, scalar);
        }
        public static Vector Divide(Vector vector, double scalar)
        {
            var result = new double[vector._total];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = vector.Get(i) / scalar;
            }
            return result;
        }
        public static double DotProduct(Vector left, Vector right)
        {
            CheckSameDimension(left, right);
            double result = 0d;
            for (int i = 0; i < left._total; i++)
            {
                result += left.Get(i) * right.Get(i);
            }
            return result;
        }

        #region operator
        public static implicit operator Vector(double[] element)
        {
            return new Vector(element, false);
        }
        public static Vector operator +(Vector left, Vector right)
        {
            return Vector.Add(left, right);
        }
        public static Vector operator -(Vector vector)
        {
            return Vector.Negate(vector);
        }
        public static Vector operator -(Vector left, Vector right)
        {
            return Vector.Subtract(left, right);
        }
        public static Vector operator *(Vector vector, double scalar)
        {
            return Vector.Multiply(vector, scalar);
        }
        public static Vector operator *(double scalar, Vector vector)
        {
            return Vector.Multiply(scalar, vector);
        }
        public static double operator *(Vector left, Vector right)
        {
            return Vector.DotProduct(left, right);
        }
        public static Vector operator /(Vector vector, double scalar)
        {
            return Vector.Divide(vector, scalar);
        }
        #endregion
    }
}
