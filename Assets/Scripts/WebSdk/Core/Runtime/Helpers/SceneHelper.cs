using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WebSdk.Core.Runtime.Helpers
{
    public static class SceneHelper
    {
        public static bool HasScene(string sceneName)
        {
            var numScenes = SceneManager.sceneCountInBuildSettings;
            
            for (int i = 0; i < numScenes; i++)
            {
                string sName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                if (sName.Equals(sceneName))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        public static void TryLoadScene(string name)
        {
            if (HasScene(name))
            {
                Debug.Log($"Load scene {name}");
                SceneManager.LoadScene(name);
            }
            else
            {
                Debug.Log($"Cannot find scene {name}");
            }
        }
        public static void LoadNextScene()
        {
            Debug.Log("Helper.LoadNextScene");

            /*var s = SceneManager.GetActiveScene();
            int currentSceneIndex = s.buildIndex;
            
            if (currentSceneIndex + 1 <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(currentSceneIndex);
            }
            else
            {
                //Application.Quit();
            }*/

            SceneManager.LoadScene("MenuScene");
        }
    }
}