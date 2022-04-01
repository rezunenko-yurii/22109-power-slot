using Core.Audio;
using Zenject;

namespace AudioSwitchers
{
    public class SoundsSwitcher : AudioSwitcher
    {
        protected override AudioController AudioController { get; set; }

        [Inject]
        private void Init(SoundsController soundsController)
        {
            AudioController = soundsController;
        }
    }
}