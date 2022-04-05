namespace Core.Signals.Implementation.Watchers.Conditions
{
    public class BetConditionWatcher //: ConditionWatcher<BetSignals.Used, BetModel>
    {
        /*protected override bool IsConditionMatches(BetSignals.Used signal, BetModel model)
        {
            return model.CurrentAmount >= model.TargetAmount;
        }
        
        protected override void UseFiredObject(BetSignals.Used signal, BetModel model, Condition condition)
        {
            base.UseFiredObject(signal, model, condition);
            model.CurrentAmount += signal.Value;
            
            condition.OnValueChanged();
        }

        protected override void LoadSubscribers()
        {
            throw new System.NotImplementedException();
        }*/
    }
}