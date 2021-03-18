using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace MathUtil.Algebra
{
    /// <summary>
    /// 向量
    /// </summary>
    [DebuggerDisplay("Vector ({Count})")]
    public sealed partial class Vector : IEnumerable<double>, IEquatable<Vector>, ICloneable, IFormattable
    {
        #region field
        private const int DoubleSize = sizeof(double);
        private readonly double[] _elements;
        private readonly int _total;
        #endregion

        #region property
        public double this[int index]
        {
            get
            {
                CheckRange(index);
                return Get(index);
            }
            set
            {
                CheckRange(index);
                Set(index, value);
            }
        }
        /// <summary>
        /// 项数
        /// </summary>
        public int Count => _total;
        #endregion

        #region constructor
        /// <summary>
        /// 创建指定长度的向量
        /// </summary>
        /// <param name="length">数值长度</param>
        public Vector(int length)
        {
            if (length < 0)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(length));
            _elements = new double[length];
            _total = _elements.Length;
        }
        /// <summary>
        /// 创建指定元素的向量
        /// </summary>
        /// <param name="element">初始元素</param>
        public Vector(double[] element)
            : this(element, true) { }
        private Vector(double[] element, bool isCopy)
        {
            if (element == null)
                ThrowHelper.ThrowArgumentNullException(nameof(element));
            if (isCopy)
            {
                _elements = new double[element.Length];
                Buffer.BlockCopy(element, 0, _elements, 0, element.Length * DoubleSize);
            }
            else
            {
                _elements = element;
            }
            _total = _elements.Length;
        }
        #endregion

        #region IEnumerable
        public IEnumerator<double> GetEnumerator()
        {
            for (int i = 0; i < _total; i++)
            {
                yield return Get(i);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _total; i++)
            {
                yield return Get(i);
            }
        }
        #endregion

        #region IEquatable
        public bool Equals(Vector other)
        {
            if (other == null)
                return false;
            if (_total != other._total)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            for (int i = 0; i < _total; i++)
            {
                if (Get(i).Equals(other.Get(i)))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region ICloneable
        object ICloneable.Clone()
        {
            return Clone();
        }
        public Vector Clone()
        {
            return new Vector(_elements, true);
        }
        #endregion

        #region IFormattable
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Join(' ', _elements.Select(p => p.ToString(format, formatProvider)));
        }
        #endregion

        #region public
        /// <summary>
        /// 数值归零
        /// </summary>
        /// <param name="threshold">阈值</param>
        public void CoerceToZero(double threshold)
        {
            for (int i = 0; i < _total; i++)
            {
                if (Get(i).IsZero(threshold))
                {
                    Set(i, 0d);
                }
            }
        }
        /// <summary>
        /// L0范数
        /// </summary>
        /// <remarks>非0元素个数</remarks>
        public double L0Norm()
        {
            var count = 0;
            for (int i = 0; i < _total; i++)
            {
                if (!Get(i).IsZero())
                    count++;
            }
            return count;
        }
        /// <summary>
        /// L1范数
        /// </summary>
        /// <remarks>元素绝对值之和</remarks>
        public double L1Norm()
        {
            double result = 0d;
            for (int i = 0; i < _total; i++)
            {
                result += Math.Abs(Get(i));
            }
            return result;
        }
        /// <summary>
        /// L2范数
        /// </summary>
        /// <remarks>元素绝对值平方和的开方</remarks>
        public double L2Norm()
        {
            return Math.Sqrt(DotProduct(this, this));
        }
        /// <summary>
        /// P阶范数
        /// </summary>
        /// <param name="p">阶数</param>
        public double Norm(double p)
        {
            if (p.IsLess(0d))
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(p));
            if (p.IsEqual(1d))
                return L1Norm();
            if (p.IsEqual(2d))
                return L2Norm();
            //元素绝对值的p次方之和的1/p次幂
            double result = 0d;
            for (var i = 0; i < _total; i++)
            {
                result += Math.Pow(Math.Abs(Get(i)), p);
            }
            return Math.Pow(result, 1.0 / p);
        }
        /// <summary>
        /// 清空向量
        /// </summary>
        public void Clear()
        {
            Array.Clear(_elements, 0, _total);
        }
        /// <summary>
        /// 转为一维数组
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            double[] result = new double[_total];
            Array.Copy(_elements, result, _total);
            return result;
        }
        public override bool Equals(object obj) => obj is Vector vector && Equals(vector);
        public override int GetHashCode() => _elements.GetHashCode();
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);
        #endregion
    }
}
