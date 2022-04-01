using Core;
using MatchGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectHintButton : AdvancedMonoBehaviour
{
    [Inject] private MatchBoostersList boostersList;
    [SerializeField] private string hintId;
    [SerializeField] private Button button;
    [SerializeField] private ScreenButton screenButton;

    [SerializeField] private Sprite unselectedSprite;
    [SerializeField] private Sprite selectedSprite;

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        
        boostersList.Names.Clear();

        int amount = PlayerPrefs.GetInt(hintId, 0);

        if (amount > 0)
        {
            MoveToUnselected();
            button.gameObject.SetActive(true);
            screenButton.gameObject.SetActive(false);
        }
        else
        {
            button.gameObject.SetActive(false);
            screenButton.gameObject.SetActive(true);
        }

    }

    private void MoveToSelected()
    {
        if (boostersList.Names.Count >= 2)
        {
            return;
        }
        
        button.onClick.RemoveListener(MoveToSelected);
        
        button.image.sprite = selectedSprite;
        button.image.SetNativeSize();
        button.onClick.AddListener(MoveToUnselected);
        
        boostersList.Add(hintId);
    }
    
    private void MoveToUnselected()
    {
        button.onClick.RemoveListener(MoveToUnselected);
        
        button.image.sprite = unselectedSprite;
        button.image.SetNativeSize();
        button.onClick.AddListener(MoveToSelected);
        
        boostersList.Remove(hintId);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        button.onClick.RemoveAllListeners();
    }
}