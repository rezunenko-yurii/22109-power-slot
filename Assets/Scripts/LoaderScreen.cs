using Core.GameScreens;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Zenject;

namespace Screens
{
    public class LoaderScreen : GameScreen
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private int _time = 2;
        [SerializeField] private string _nextScreen;

        [Inject] private ScreensManager _screensManager;
    
        private MoveSlider _moveSlider;

        public void Load()
        {
            Debug.Log($"{nameof(LoaderScreen)} {nameof(Load)} {Time.time}");
        
            _moveSlider = new MoveSlider(this, _slider, _time);
            _moveSlider.Execute().Done += OnLoaded;
        }

        protected override void OnShowed(PlayableDirector obj)
        {
            Load();
        
            base.OnShowed(obj);
        }

        private void OnLoaded(Instruction i)
        {
            Debug.Log($"{nameof(LoaderScreen)} {nameof(OnLoaded)} {Time.time}");
        
            _moveSlider.Done -= OnLoaded;
            _moveSlider = null;
        
            /*Completed?.Invoke();
        Completed = null;*/
        
            _screensManager.Show(_nextScreen);
        }
    }
}
