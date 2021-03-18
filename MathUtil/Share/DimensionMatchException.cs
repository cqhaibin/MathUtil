using System;

namespace MathUtil
{
    /// <summary>
    /// 维度匹配异常
    /// </summary>
    public class DimensionMatchException : Exception
    {
        private const string _defaultMessage = "维度不匹配!";
        public DimensionMatchException()
            : base(_defaultMessage) { }
    }
}
