using Modules.Timers.Scripts;
using Zenject;

namespace DefaultNamespace
{
    public class DailyBonusTimerText : TimerText
    {
        [Inject(Id = ModuleType.DailyBonus)] protected override MemoryTimer Timer { get; }
    }
}