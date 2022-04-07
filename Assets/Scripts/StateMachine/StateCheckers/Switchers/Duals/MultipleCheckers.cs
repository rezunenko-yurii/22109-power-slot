using UnityEngine;

namespace StateMachine.StateCheckers.Switchers.Duals
{
    public class MultipleCheckers : DualStateChecker
    {
        [SerializeField] protected StateChecker[] checkers;
    }
}