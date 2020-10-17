using System;

namespace Algorithms.Lib.Helpers
{
    public static class AlgorithmsHelper
    {
        public static void ThrowArgumentExceptionIfDataTypeIsClassAndNotString(Type type)
        {
            if (type.IsClass && !type.Equals(typeof(string)))
                throw new ArgumentException("Only call this function on non classes and strings.");
        }
    }
}
