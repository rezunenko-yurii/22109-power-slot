using UnityEngine;

namespace Core
{
    public class SaveArea : MonoBehaviour
    {
        private Rect _lastSafeArea;
        private (int width, int height) lastScreenSize;
        
        private RectTransform _rectTransform;

        private void Start() 
        {
            _rectTransform = GetComponent<RectTransform>();
        
            ApplySafeArea();
        }

        private void Update() 
        {
            if (_lastSafeArea != Screen.safeArea 
                || lastScreenSize.width != Screen.width 
                || lastScreenSize.height != Screen.height) 
            {
                ApplySafeArea();
            }
        }

        private void ApplySafeArea() 
        {
            Vector2 anchorMin = Screen.safeArea.position;
            Vector2 anchorMax = Screen.safeArea.position + Screen.safeArea.size;
            
            anchorMin.x /= Screen.width;
            anchorMax.x /= Screen.width;

            if (Screen.orientation == ScreenOrientation.Portrait)
            {
                anchorMin.y /= Screen.height;
                anchorMax.y /= Screen.height;
            }
            else
            {
                anchorMin.y = 0;
                anchorMax.y = 1;
            }
            
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
            
            _lastSafeArea = Screen.safeArea;
            lastScreenSize.width = Screen.width;
            lastScreenSize.height = Screen.height;
        }
    }
}
