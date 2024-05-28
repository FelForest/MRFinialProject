using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnButtonClick : MonoBehaviour
{
    public string sceneName = "Landing"; 

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
