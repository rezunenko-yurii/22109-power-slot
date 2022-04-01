using System;
using System.Collections.Generic;

namespace Core.Messages.Subscribers
{
    public class Subscribers
    {
        public List<Action<object>> List { get; } = new List<Action<object>>();

        public void Invoke(object obj)
        {
            foreach (var action in List)
            {
                action.Invoke(obj);
            }
        }

        public void Add(Action<object> action)
        {
            List.Add(action);
        }
    }
}