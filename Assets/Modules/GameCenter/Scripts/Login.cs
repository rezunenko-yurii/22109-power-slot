using UnityEngine;

namespace GameCenter
{
    public class Login
    {
        public bool IsLogged { get; private set; }

        public Login()
        {
            Debug.Log($"GameCenter {nameof(Login)} constructor");
            Social.localUser.Authenticate((success) =>
            {
                if (success)
                {
                    IsLogged = true;
                    Debug.Log($"GameCenter {nameof(Login)} successfully authenticated");
                }
                else
                {
                    Debug.LogError($"GameCenter {nameof(Login)} authentication failed");
                }
            });
        }
    }
}