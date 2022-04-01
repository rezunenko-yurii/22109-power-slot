using System;
using System.Collections.Generic;

namespace MatchGame
{
    public class MatchBoostersList
    {
        public event Action Changed;
        
        public List<string> Names = new List<string>();

        public void Add(string s)
        {
            Names.Add(s);
            Changed?.Invoke();
        }

        public void Remove(string s)
        {
            Names.Remove(s);
            Changed?.Invoke();
        }
    }
}