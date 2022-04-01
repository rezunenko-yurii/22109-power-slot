using UnityEngine;
using UnityEngine.UI;

namespace Lives
{
    public class LiveView : MonoBehaviour
    {
        [SerializeField] private Image image = null;
        [SerializeField] private Sprite active = null;
        [SerializeField] private Sprite inactive = null;

        public void SetSprite(bool isActive)
        {
            SetSprite(isActive ? active : inactive);
        }

        private void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
            image.SetNativeSize();
        }
    }
}