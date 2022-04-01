using Core.Moneys;

namespace Core.Finances.Moneys
{
    public sealed class MoneySignals
    {
        public abstract class BaseMoneySignal
        {
            public readonly float Value;

            protected BaseMoneySignal(float value)
            {
                Value = value;
            }
        }
        
        public class Added<T> : BaseMoneySignal where T : class, IMoney
        {
            public Added(float value) : base(value) { }
        }
        
        public class Changed<T> : BaseMoneySignal where T : class, IMoney
        {
            public Changed(float value) : base(value) { }
        }
        
        public class Subtracted<T> : BaseMoneySignal where T : class, IMoney
        {
            public Subtracted(float value) : base(value) { }
        }
    }
}