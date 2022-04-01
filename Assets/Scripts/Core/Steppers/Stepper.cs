using System;

namespace Core.Steppers
{
    public class Stepper<T>
    {
        public event Action<int,T> Changed;
        
        private T[] _values;
        private int _position;

        public Stepper(T[] values, int startPosition = 0)
        {
            _values = values;
            _position = 0;
        }
        
        public void SetNext()
        {
            if (_position + 1 < _values.Length)
            {
                Set(_position + 1);
            }
            else
            {
                Set(0);
            }
        
            InvokeOnChanged();
        }

        public void SetPrevious()
        {
            if (_position - 1 >= 0)
            {
                Set(_position - 1);
            }
            else
            {
                Set(_values.Length - 1);
            }
        }

        public void SetLast()
        {
            Set(_values.Length - 1);
        }

        public void Set(int newPosition)
        {
            _position = newPosition;
            InvokeOnChanged();
        }

        public int CurrentPosition => _position;
        public T CurrentValue => _values[_position];
        private void InvokeOnChanged() => Changed?.Invoke(_position, CurrentValue);
    }
}