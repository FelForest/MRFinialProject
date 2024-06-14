using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class TriggerZone : MonoBehaviour
{
    public GameObject canvas;
    public Text messageText;

    private bool playerInZone = false;

    public string sceneName = "Cockpit"; 
    public float delay = 1.0f; // 딜레이 시간 (초 단위)

    public  GameObject Fade; 

    void Start()
    {
        canvas.SetActive(false);
        messageText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 특정 위치에 도착하면 Canvas와 Text를 활성화
            canvas.SetActive(true);
            messageText.gameObject.SetActive(true);
            playerInZone = true;
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.Q))
        {
            // Q키를 누르면 Canvas와 Text를 비활성화
            canvas.SetActive(false);
            messageText.gameObject.SetActive(false);
            playerInZone = false;

            StartCoroutine(LoadSceneAfterDelay());

            Fade.GetComponent<Fade>().FadeStart(); 
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

