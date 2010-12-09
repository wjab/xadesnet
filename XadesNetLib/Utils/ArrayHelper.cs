using System;

namespace XadesNetLib.Utils
{
    public class ArrayHelper
    {
        public static bool ArrayHasSameLengthAsAny(object[] reference, params object[][] toCompare)
        {
            if (reference == null) return false;
            foreach (var arrayToCompare in toCompare)
            {
                if ((arrayToCompare != null) && (reference.Length == arrayToCompare.Length))
                    return true;
            }
            return false;
        }

        public static void DoWithFirstNotEmpty(Action<object> action, params object[][] arrays)
        {
            object[] firstNotEmptyArray = null;
            foreach (var array in arrays)
            {
                if (array.Length <= 0) continue;
                firstNotEmptyArray = array;
                break;
            }
            if (firstNotEmptyArray == null) return;
            foreach (var objectInArray in firstNotEmptyArray)
            {
                action(objectInArray);
            }
        }

        public static bool ArraysAreEqual(object[] array1, object[] array2)
        {
            if (array1 == null) return array2 == null;
            if (array2 == null) return false;
            if (array1.Length != array2.Length) return false;
            for (var i = 0; i < array1.Length; i++)
            {
                if (!array1[i].Equals(array2[i])) return false;
            }
            return true;
        }
        public static bool ArraysAreEqual(byte[] array1, byte[] array2)
        {
            if (array1 == null) return array2 == null;
            if (array2 == null) return false;
            if (array1.Length != array2.Length) return false;
            for (var i = 0; i < array1.Length; i++)
            {
                if (!array1[i].Equals(array2[i])) return false;
            }
            return true;
        }
    }
}