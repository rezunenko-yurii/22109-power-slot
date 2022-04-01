using UnityEngine;
using Zenject;

namespace GameCenter
{
    public abstract class GameCenterItem
    {
        [Inject] protected Login login;
        [Inject] protected SignalBus signalBus;

        public abstract void ShowBoard();

        public virtual void TryReport(int value)
        {
#if !UNITY_IOS
                return;
#endif
            if (!login.IsLogged)
            {
                Debug.LogWarning("Can`t show board. User isn`t authenticated");
                return;
            }
            else
            {
                Report(value);
            }
        }

        protected abstract void Report(int value);

        protected void ReportResult(bool result)
        {
            Debug.Log(result ? $"Successfully reported score" : $"Failed to report score");
        }
    }
}