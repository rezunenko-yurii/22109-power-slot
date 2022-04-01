using DailyBonusModule;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class DailyBonusOpenedState : DailyBonusState
{
    [SerializeField] private Sprite sprite;
    [Inject] private DailyBonusesManager _bonusesManager;
    
    private Sequence shakeSequence;
    
    protected override DailyBonusStates State { get; } = DailyBonusStates.Opened;
    public override void Apply()
    {
        /*shakeSequence = DOTween.Sequence();
        shakeSequence
            .Append(Context.transform.DOPunchScale(new Vector2(0.3f, 0.3f), 0.75f, 5))
            .AppendCallback(OnComplete)
            .AppendInterval(0.3f)
            .AppendCallback(GiveReward);*/
        Context.Skin.sprite = sprite;
        GiveReward();
    }

    public override void BeforeChanged()
    {
        //throw new System.NotImplementedException();
    }

    public override bool CanApply(int itemDay, int currentDay, int passedDay)
    {
        return currentDay == itemDay && passedDay >= 1;
    }

    public void OnComplete()
    {
        Debug.Log("Change skin");
        Context.Skin.sprite = sprite;
    }

    private void GiveReward()
    {
        Debug.Log("GiveReward");
        
        _bonusesManager.GiveBonus();
    }

    private void OnDestroy()
    {
        //shakeSequence.Kill();
    }
}
