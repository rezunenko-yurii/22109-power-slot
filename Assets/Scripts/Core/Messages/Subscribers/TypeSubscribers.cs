using System;
using System.Collections.Generic;

namespace Core.Messages.Subscribers
{
    public class TypeSubscribers
    {
        private Dictionary<Type, Subscribers> _dictionary;
        public Subscribers Callbacks { get; } = new Subscribers();

        public bool Contains(Type type) => _dictionary.ContainsKey(type);

        public TypeSubscribers()
        {
            _dictionary = new Dictionary<Type, Subscribers>(){};
        }
        
        public void Invoke()
        {
            Type type = typeof(EmptyType);
            Invoke(type, null);
        }

        public void Invoke(Type type)
        {
            Invoke(type, null);
        }
        
        public void Invoke(object obj)
        {
            Invoke(obj.GetType(), obj);
        }
        
        public void Invoke(Type type, object obj)
        {
            if (_dictionary.TryGetValue(type, out var subscribers))
            {
                subscribers.Invoke(obj);
            }
        }

        public void Add(Type type, Action<object> action)
        {
            CreateNewSubscribers(type);
            var d = _dictionary[type];
            d.Add(action);
        }
        
        public void Add(Action<object> action)
        {
            Type type = typeof(EmptyType);

            CreateNewSubscribers(type);
            
            var d = _dictionary[typeof(EmptyType)];
            d.Add(action);
        }

        private void CreateNewSubscribers(Type type)
        {
            if (!_dictionary.ContainsKey(type))
            {
                _dictionary.Add(type, new Subscribers());
            }
        }
    }
}