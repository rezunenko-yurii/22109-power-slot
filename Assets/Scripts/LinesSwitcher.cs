using Core;
using SlotsGame.Scripts.Lines;
using UnityEngine;
using Zenject;

public class LinesSwitcher : AdvancedMonoBehaviour
{
    [SerializeField] private SpriteRenderer[] linesObjects;
    [Inject] private LinesManager _linesManager;
    
    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        OnLinesCountChanged();
    }

    protected override void AddListeners()
    {
        _linesManager.CountChanged += OnLinesCountChanged;
    }

    protected override void RemoveListeners()
    {
        _linesManager.CountChanged -= OnLinesCountChanged;
    }

    private void OnLinesCountChanged(int count = 0)
    {
        HideAllLines();
        ShowLines();
    }

    private void ShowLines()
    {
        for (int i = 0; i <= _linesManager.Count; i++)
        {
            //linesObjects[i].SetActive(true);
            linesObjects[i].enabled = true;
        }
    }

    private void HideAllLines()
    {
        foreach (var lineObject in linesObjects)
        {
            //lineObject.SetActive(false);
            lineObject.enabled = false;
        }
    }
}
