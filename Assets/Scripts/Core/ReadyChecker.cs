using System;

namespace Core
{
    public class ReadyChecker
    {
        public bool IsReady;

        public void TryInvoke(Action action)
        {
            if (IsReady)
            {
                action.Invoke();
            }
        }
    }
}