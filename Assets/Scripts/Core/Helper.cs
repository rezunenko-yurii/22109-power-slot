using System;
using System.Linq;

namespace Core
{
    public static class Helper
    {
        public static TAttribute GetAttribute<TAttribute>(object obj) where TAttribute : class
        {
            var t = obj.GetType();
            return GetAttribute<TAttribute>(t);
        }
        
        public static TAttribute GetAttribute<TType, TAttribute>() where TAttribute : class
        {
            var t = typeof(TType);
            return GetAttribute<TAttribute>(t);
        }
        
        public static TAttribute GetAttribute<TAttribute>(Type type) where TAttribute : class
        {
            var attrs = type.GetCustomAttributes(typeof(TAttribute), true);
            
            if (attrs.FirstOrDefault() is TAttribute dnAttribute)
            {
                return dnAttribute;
            }
            
            return null;
        }
    }
}