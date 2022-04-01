using System;
using Zenject;

namespace SlotsGame.Scripts.AutoSpins.Modes
{
    public class AutoSpinModesFactory
    {
        private DiContainer _container;
        
        private Off _off;
        private Infinity _infinity;
        private ForciblyAmount _forciblyAmount;
        
        public AutoSpinModesFactory(DiContainer container)
        {
            _container = container;
            
            _off = _container.Instantiate<Off>();
            _infinity = _container.Instantiate<Infinity>();
            _forciblyAmount = _container.Instantiate<ForciblyAmount>();
        }
        
        public AutoSpinMode Create(AutoSpinType type)
        {
            AutoSpinMode handler = type switch
            {
                AutoSpinType.Off => _off,
                AutoSpinType.Infinity => _infinity,
                AutoSpinType.ForcedAmount => _forciblyAmount,
                _ => throw new Exception("No requested mode")
            };

            return handler;
        }
    }
}