using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTextOnTrigger : MonoBehaviour
{
    public Text legacyText; // 화면에 띄울 텍스트 (Legacy UI)
    private bool playerInTriggerZone = false; // 플레이어가 트리거 존에 있는지 확인

    void Start()
    {
        // 처음에는 텍스트를 비활성화합니다.
        legacyText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // 플레이어가 트리거 존에 들어오면
        if (other.CompareTag("Player"))
        {
            playerInTriggerZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 플레이어가 트리거 존에서 나가면
        if (other.CompareTag("Player"))
        {
            playerInTriggerZone = false;
        }
    }

    void Update()
    {
        // 플레이어가 트리거 존에 있고 'E' 키를 누르면 텍스트를 활성화합니다.
        if (playerInTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ShowTextWithDelay());
        }
    }

    IEnumerator ShowTextWithDelay()
    {
        // 1초 딜레이
        yield return new WaitForSeconds(1.0f);

        // 텍스트 활성화
        legacyText.gameObject.SetActive(true);
    }
}
