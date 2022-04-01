using Core.Audio;
using Core.Buttons;
using UnityEngine;

namespace AudioSwitchers
{
    public abstract class AudioSwitcher : MonoBehaviour
    {
        [SerializeField] private RadioButton switcher;
        protected abstract AudioController AudioController { get; set; }

        void Awake()
        {
            Debug.Log($"{nameof(AudioSwitcher)} {nameof(Awake)}");
            SetStateByAudioVolume();
        }

        private void SetStateByAudioVolume()
        {
            bool isSoundOn = AudioController.Volume > 0;
            switcher.ChangeState(isSoundOn, false);
        
            Debug.Log($"{nameof(AudioSwitcher)} {nameof(SetStateByAudioVolume)} / Volume={AudioController.Volume} isSoundOn={isSoundOn}");
        }

        private void OnEnable()
        {
            switcher.StateChanged += SetSwitcherState;
        }
    
        private void OnDisable()
        {
            switcher.StateChanged -= SetSwitcherState;
        }
    
        private void SetSwitcherState(bool value, RadioButton button)
        {
            AudioController.Volume = value switch
            {
                true => 1f,
                false => 0f,
            };
        }
    }
}
