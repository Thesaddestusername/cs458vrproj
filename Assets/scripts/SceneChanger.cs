using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // Name of the scene you want to load

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
