using UnityEngine;
using UnityEngine.UI;

namespace SlotsGame.Scripts.Slot
{
    public class Selector : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer image;

        private void Awake()
        {
            Hide();
        }

        public void Hide()
        {
            image.enabled = false;
        }
        
        public void Show()
        {
            image.enabled = true;
        }
    }
}