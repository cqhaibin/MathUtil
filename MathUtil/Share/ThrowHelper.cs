using System;
using System.Diagnostics.CodeAnalysis;

namespace MathUtil
{
    internal static class ThrowHelper
    {
        private const string EmptyString = "";

        /// <summary>
        /// 不支持的操作
        /// </summary>
        [DoesNotReturn]
        public static void ThrowNotSupportedException(string message) => throw new NotSupportedException(message);
        /// <summary>
        /// 参数为空
        /// </summary>
        /// <param name="argumentName">参数名</param>
        [DoesNotReturn]
        internal static void ThrowArgumentNullException(string argumentName) => throw new ArgumentNullException(argumentName);
        /// <summary>
        /// 参数非法
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="argumentName">参数名</param>
        [DoesNotReturn]
        internal static void ThrowIllegalArgumentException(string message, string argumentName = EmptyString) => throw new ArgumentException(message, argumentName);
        /// <summary>
        /// 参数越界
        /// </summary>
        /// <param name="argumentName">参数名</param>
        [DoesNotReturn]
        internal static void ThrowArgumentOutOfRangeException(string argumentName) => throw new ArgumentOutOfRangeException(argumentName);
        /// <summary>
        /// 索引越界
        /// </summary>
        /// <param name="argumentName">参数名</param>
        [DoesNotReturn]
        internal static void ThrowIndexOutOfRangeException(string argumentName) => throw new IndexOutOfRangeException($"{ErrorReason.IndexOutOfRange}!参数:{argumentName}");
        /// <summary>
        /// 计算异常
        /// </summary>
        /// <param name="message">错误消息</param>
        [DoesNotReturn]
        internal static void ThrowArithmeticException(string message) => throw new ArithmeticException(message);
        /// <summary>
        /// 维度异常
        /// </summary>
        [DoesNotReturn]
        internal static void ThrowDimensionDontMatchException() => throw new DimensionMatchException();
    }
}
