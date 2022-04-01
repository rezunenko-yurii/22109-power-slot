using UnityEngine;

namespace StateMachine.StateCheckers
{
    public class FirstOpenScreenChecker : DualStateChecker
    {
        [SerializeField] protected string screenId;
        
        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            Check();
        }
        
        private void Check()
        {
            string id = $"first_open_{screenId}";
            string a = PlayerPrefs.GetString(id);
            
            if (!string.IsNullOrEmpty(a))
            {
                SetAllActive();
            }
            else
            {
                SetAllInactive();
            }
        }
    }
}