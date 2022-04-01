using Core.Audio;
using Zenject;

namespace AudioSwitchers
{
    public class MusicSwitcher : AudioSwitcher
    {
        protected override AudioController AudioController { get; set; }
        
        [Inject]
        private void Init(MusicController musicController)
        {
            AudioController = musicController;
        }
    }
}