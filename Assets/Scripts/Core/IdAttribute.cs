using System;

namespace Core
{
    public class IdAttribute: Attribute
    {
        public readonly string Value;
        
        public IdAttribute(string value)
        {
            Value = value;
        }
        public bool IsEquals(string value)
        {
            return Value.Equals(value);
        }
    }
}