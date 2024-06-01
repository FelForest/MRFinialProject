using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스 추가
using UnityEngine.UI;
using System.Collections;

public class CameraSwitch : MonoBehaviour
{
    public Camera internalCamera;
    public Camera externalCamera;
    public TMP_Text worldSpaceCountdownText; // 내부시점에서 보이는 TextMeshPro 텍스트
    public TMP_Text screenSpaceCountdownText; // 외부시점에서 보이는 TextMeshPro 텍스트
    public Button startButton;
    public RocketLauncher rocketLauncher; // 로켓 런처 스크립트 참조

    void Start()
    {
        // Null 체크 추가
        if (externalCamera == null)
        {
            Debug.LogError("externalCamera is not assigned."); // 추가됨
            return; // 추가됨
        }

        if (internalCamera == null)
        {
            Debug.LogError("internalCamera is not assigned."); // 추가됨
            return; // 추가됨
        }

        if (worldSpaceCountdownText == null)
        {
            Debug.LogError("worldSpaceCountdownText is not assigned."); // 추가됨
            return; // 추가됨
        }

        if (screenSpaceCountdownText == null)
        {
            Debug.LogError("screenSpaceCountdownText is not assigned."); // 추가됨
            return; // 추가됨
        }

        if (startButton == null)
        {
            Debug.LogError("startButton is not assigned."); // 추가됨
            return; // 추가됨
        }

        if (rocketLauncher == null)
        {
            Debug.LogError("rocketLauncher is not assigned."); // 추가됨
            return; // 추가됨
        }

        // 초기 설정
        externalCamera.enabled = false;
        internalCamera.enabled = true;
        screenSpaceCountdownText.gameObject.SetActive(false);
        worldSpaceCountdownText.gameObject.SetActive(false);

        // 버튼 클릭 이벤트 연결
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        // 버튼 비활성화
        startButton.gameObject.SetActive(false);

        // 카운트다운 텍스트 활성화
        screenSpaceCountdownText.gameObject.SetActive(false); // 수정됨: true에서 false로 변경
        worldSpaceCountdownText.gameObject.SetActive(true);

        // 카운트다운 시작
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        int countdown = 10;

        while (countdown > 0)
        {
            screenSpaceCountdownText.text = countdown.ToString();
            worldSpaceCountdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1.0f);
            countdown--;

            if (countdown == 4)
            {
                // 4초일 때 카메라 전환
                internalCamera.enabled = false;
                externalCamera.enabled = true;

                // 외부시점에서는 worldSpaceCountdownText 비활성화
                worldSpaceCountdownText.gameObject.SetActive(false);
                screenSpaceCountdownText.gameObject.SetActive(true); // 추가됨
            }
        }

        // 카운트다운이 끝나면 텍스트 비활성화
        screenSpaceCountdownText.gameObject.SetActive(false);
        worldSpaceCountdownText.gameObject.SetActive(false);

        // 로켓 발사
        rocketLauncher.Launch();
    }
}
