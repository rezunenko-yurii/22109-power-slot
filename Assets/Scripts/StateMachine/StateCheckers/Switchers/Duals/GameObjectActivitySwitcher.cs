namespace StateMachine.StateCheckers.Switchers.Duals
{
    public class GameObjectActivitySwitcher : Switcher
    {
        public override void OnTrue()
        {
            gameObject.SetActive(true);
        }

        public override void OnFalse()
        {
            gameObject.SetActive(false);
        }
    }
}