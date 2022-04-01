using System;
using System.Collections.Generic;

namespace Core.Messages.Subscribers
{
    public class MessagesSubscribers
    {
        private Dictionary<MessagesType, TypeSubscribers> subscribers =
            new Dictionary<MessagesType, TypeSubscribers>();

        public bool Contains(MessagesType eventType) => subscribers.ContainsKey(eventType);
        public TypeSubscribers GetSubscribersByType(MessagesType eventType) => subscribers[eventType];

        public void Add(MessagesType eventType, Type type, Action<object> action)
        {
            if (!subscribers.ContainsKey(eventType))
            {
                subscribers.Add(eventType, new TypeSubscribers());    
            }
            
            subscribers[eventType].Add(type, action);
        }
        
        public void Add(MessagesType eventType, Action<object> action)
        {
            if (!subscribers.ContainsKey(eventType))
            {
                subscribers.Add(eventType, new TypeSubscribers());    
            }
            
            subscribers[eventType].Add(action);
        }
        
        public void Remove(MessagesType eventType, Type paramType, Action<object> action)
        {
            if (subscribers.ContainsKey(eventType))
            {
                //subscribers.Remove(eventType,)
            }
        }

        public void Invoke(MessagesType eventType)
        {
            if (subscribers.ContainsKey(eventType))
            {
                subscribers[eventType].Invoke();
            }
        }
        
        public void Invoke(MessagesType eventType, Object obj)
        {
            if (subscribers.ContainsKey(eventType))
            {
                subscribers[eventType].Invoke(obj);
            }
        }
    }
}