using Core;
using UnityEngine;
using Zenject;

namespace Lives
{
    public class LiveViews : AdvancedMonoBehaviour
    {
        [Inject] private LivesManager _livesManager;
        [SerializeField] private LiveView[] _lives;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();

            for (var i = 0; i < _lives.Length; i++)
            {
                var liveView = _lives[i];
                bool isLiveActive = (i + 1) <= _livesManager.ActiveLivesAmount;
                liveView.SetSprite(isLiveActive);
            }
        }
    }
}