using System.Collections.Generic;

namespace Modules.Dates
{
    public class DateKeepers
    {
        private Dictionary<string, DateKeeper> _dictionary = new Dictionary<string, DateKeeper>();

        public T Get<T>(string id) where T : DateKeeper, new()
        {
            if (!Contains(id))
            {
                Create<T>(id);
            }

            return _dictionary[id] as T;
        }

        public bool Contains(string id) => _dictionary.ContainsKey(id);

        private void Create<T>(string id) where T : DateKeeper, new()
        {
            var dateKeeper = new T();
            dateKeeper.Init(id);
            
            _dictionary.Add(id, dateKeeper);
        }
    }
}