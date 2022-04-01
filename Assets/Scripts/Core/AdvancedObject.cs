using System;
using Zenject;

namespace Core
{
    public abstract class AdvancedObject : IInitializable, IDisposable
    {
        public void Initialize()
        {
            Prepare();
            AddListeners();
        }
        
        public void Dispose()
        {
            RemoveListeners();
        }
        
        protected virtual void Prepare() { }
        protected virtual void AddListeners() { }
        protected virtual void RemoveListeners() { }
    }
}