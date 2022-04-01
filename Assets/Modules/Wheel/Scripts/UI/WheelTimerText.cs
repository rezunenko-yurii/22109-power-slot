using Modules.Timers.Scripts;
using Zenject;

namespace WheelLib.UI
{
    public class WheelTimerText : TimerText
    {
        [Inject(Id = ModuleType.Wheel)] protected override MemoryTimer Timer { get; }
    }
}