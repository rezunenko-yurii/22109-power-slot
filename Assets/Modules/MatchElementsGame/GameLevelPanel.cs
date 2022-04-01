using Core;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameLevelPanel : AdvancedMonoBehaviour
{
    private TextMeshProUGUI textfield;
    protected override void Awake()
    {
        base.Awake();
        textfield = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        UpdateText();
    }

    public void UpdateText()
    {
        int level = PlayerPrefs.GetInt("level", 1);
        textfield.text = level.ToString();
    }
}
