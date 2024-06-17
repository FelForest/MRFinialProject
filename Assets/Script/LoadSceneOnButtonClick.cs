using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnButtonClick : MonoBehaviour
{
    public string sceneName = "Landing";
    public Fade fade;

    public void NextScene()
    {
        fade.FadeStart();
        Invoke("LoadScene", fade.fadeTime);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
