using System;
using Core.Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : AdvancedButtonUI
{
    [SerializeField] private string sceneName;

    protected override void OnClick()
    {
        base.OnClick();

        if (sceneName.Equals(string.Empty))
        {
            throw new Exception("Scene name should not be empty");
        }
        else
        {
            Debug.Log($"Load Scene {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
    }
}
