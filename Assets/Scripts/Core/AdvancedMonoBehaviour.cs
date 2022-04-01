using UnityEngine;
using Zenject;

namespace Core
{
    public abstract class AdvancedMonoBehaviour : MonoBehaviour
    {
        private ReadyChecker _readyChecker;

        protected virtual void Awake()
        {
            _readyChecker = new ReadyChecker();
        }

        protected virtual void Start()
        {
            _readyChecker.IsReady = true;
            
            Initialize();
            OnEnableInitialized();
            Main();
        }
        
        protected virtual void Main() { }

        protected virtual void OnEnable()
        {
            //Debug.Log($"{this.name} {nameof(AdvancedMonoBehaviour)} {nameof(OnEnable)}");
            _readyChecker.TryInvoke(OnEnableInitialized);
        }

        protected virtual void OnEnableInitialized()
        {
            AddListeners();
        }
        
        protected virtual void OnDisable()
        {
            //Debug.Log($"{this.name} {nameof(AdvancedMonoBehaviour)} {nameof(OnDisable)}");
            _readyChecker.TryInvoke(OnDisableInitialized);
        }

        protected virtual void OnDisableInitialized()
        {
            RemoveListeners();
        }
        
        protected virtual void Initialize(){} 
        protected virtual void AddListeners() { }
        protected virtual void RemoveListeners() { }
        protected virtual void OnDestroy() { }
    }
}