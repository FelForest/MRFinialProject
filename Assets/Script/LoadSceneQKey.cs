using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneQKey : MonoBehaviour
{
    public string sceneName = "Cockpit"; 
    public float delay = 1.0f; // 딜레이 시간 (초 단위)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
