using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TriggerZone : MonoBehaviour
{
    public GameObject canvas;
    public Text messageText;

    private bool playerInZone = false;

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
        }
    }
}

