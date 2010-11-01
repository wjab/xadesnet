using System;
using System.Reflection;

namespace Testing
{
    public class TestingHelper
    {
        const BindingFlags Flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        private TestingHelper()
        {

        }

        #region Run Method
                      
        public static object ExecStaticMethod(Type sourceType, string sourceMethod, object[] param)
        {            
            return ExecMethod(sourceType, sourceMethod, null, param, Flags);
        }
        
        public static object ExecMethodFromInstance(Type sourceType, string sourceMethod, object instance, object[] param)
        {        
            return ExecMethod(sourceType, sourceMethod, instance, param, Flags);
        }

        private static object ExecMethod(IReflect sourceType, string metodo, object sourceMethod, object[] param, BindingFlags flags)
        {
            var m = sourceType.GetMethod(metodo, flags);
            if (m == null)
            {
                throw new ArgumentException(string.Format("Unknown methond '{0}' in type '{1}'.", metodo, sourceType));
            }

            var objRet = m.Invoke(sourceMethod, param);
            return objRet;
        } 

        #endregion

    }
}
