using System;
using Core.Messages.Subscribers;

namespace Core.Messages
{
    public class MessagesSystem
    {
        private MessagesSubscribers subscribers = new MessagesSubscribers();

        public void Subscribe(MessagesType eventType, Type paramType, Action<object> action)
        {
            subscribers.Add(eventType, paramType, action);
        }
        
        public void Subscribe(MessagesType eventType, Action<object> action)
        {
            subscribers.Add(eventType, action);
        }
        
        public void UnSubscribe(MessagesType eventType, Type paramType, Action<object> action)
        {
            subscribers.Remove(eventType, paramType, action);
        }
        
        public void UnSubscribe(MessagesType eventType, Action<object> action)
        {
            //subscribers.Remove(eventType, action);
        }

        public void Invoke(MessagesType eventType)
        {
            subscribers.Invoke(eventType);
        }
        
        public void Invoke(MessagesType eventType, object obj)
        {
            subscribers.Invoke(eventType, obj);
        }
    }
}