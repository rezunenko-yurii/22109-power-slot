using StateMachine.StateCheckers.Switchers.Duals;

namespace StateMachine
{
    public class DualStateChecker : StateChecker
    {
        protected void SetAllActive()
        {
            foreach (Switcher switcher in switchers)
            {
                if (switcher != null)
                {
                    switcher.Input(true);
                    //switcher.SetActiveState();
                }
            }
        }
        
        protected void SetAllInactive()
        {
            foreach (Switcher switcher in switchers)
            {
                if (switcher != null)
                {
                    switcher.Input(false);
                    //switcher.SetInactiveState();
                }
            }
        }
    }
}