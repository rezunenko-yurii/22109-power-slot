using Core;
using StateMachine.StateCheckers.Switchers;
using StateMachine.StateCheckers.Switchers.Duals;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateChecker : AdvancedMonoBehaviour
    {
        [SerializeField] protected Switcher[] switchers;
    }
}