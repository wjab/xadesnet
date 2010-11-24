using System;
using System.Linq;

namespace XadesNetLib.Utils
{
    public class ArrayHelper
    {
        public static bool ArrayHasSameLengthAsAny(object[] reference, params object[][] toCompare)
        {
            if (reference == null) return false;
            return toCompare.Any(arrayToCompare => 
                arrayToCompare != null && reference.Length == arrayToCompare.Length);
        }

        public static void DoWithFirstNotEmpty(Action<object> action, params object[][] arrays)
        {
            var firstNotEmptyArray = arrays.FirstOrDefault(array => array.Length > 0);
            if (firstNotEmptyArray == null) return;
            foreach (var objectInArray in firstNotEmptyArray)
            {
                action(objectInArray);
            }
        }
    }
}