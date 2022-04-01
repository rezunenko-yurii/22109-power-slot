using System.Collections.Generic;

namespace SlotsGame.Scripts.ChipsLib
{
    public class ChipBlueprintChanger
    {
        private Stack<Blueprint> _stack = new Stack<Blueprint>();
        private int MaxAmount = 30;
        
        public void Add(Blueprint blueprint)
        {
            if (!IsStackFool)
            {
                _stack.Push(blueprint);
            }
        }

        public bool IsStackFool => _stack.Count >= MaxAmount;

        public Blueprint GetBlueprient()
        {
            return _stack.Pop();
        }

        public int Amount => _stack.Count;
    }
}