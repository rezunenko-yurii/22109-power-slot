using Core.GameScreens;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Scene : UIObject
    {
        [Inject] private ScreensManager screensManager;
        [Inject] private Scenes scenes;
        
        protected SceneModel sceneModel { get; private set; }
        
        protected override void Initialize()
        {
            base.Initialize();
            sceneModel = scenes.GetObject(Id);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        protected override void Main()
        {
            base.Main();
            screensManager.Show(sceneModel.StartScreenId);
        }
    }
}