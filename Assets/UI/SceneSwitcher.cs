using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public void SwitchScene () {
        int sceneCount          = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex   = SceneManager.GetActiveScene ().buildIndex;

        int nextSceneIndex = (currentSceneIndex + 1) % sceneCount;
        SceneManager.LoadScene (nextSceneIndex);
    }
}
