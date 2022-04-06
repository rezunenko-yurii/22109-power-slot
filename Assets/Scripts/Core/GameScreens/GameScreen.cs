using Core.Audio;
using UI;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

namespace Core.GameScreens
{
    public class GameScreen : UIObject
    {
        [Inject] private MusicController _musicController;
        [SerializeField] protected AudioClip audioClip;
        protected override void OnShowed(PlayableDirector obj)
        {
            base.OnShowed(obj);
            _musicController.TryPlay(audioClip);
        }
    }
}