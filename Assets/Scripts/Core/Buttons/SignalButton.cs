using Core.GameScreens;
using UnityEngine;
using Zenject;

namespace Core.Buttons
{
    public class SignalButton : AdvancedButtonUI
    {
        [Inject] protected SignalBus signalBus;
    }
}
