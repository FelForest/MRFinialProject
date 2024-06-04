using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // 카운트다운을 표시할 TextMeshPro UI
    public Camera internalCamera; // 내부 시점을 위한 카메라
    public Camera externalCamera; // 외부 시점을 위한 카메라
    public float countdownTime = 10; // 카운트다운 시간 (초)
    private float currentTime;
    private bool countdownActive = false;

    void Start()
    {
        // 초기에는 카운트다운 비활성화
        currentTime = -1;
        internalCamera.enabled = true;
        externalCamera.enabled = false;
    }

    void Update()
    {
        if (countdownActive)
        {
            currentTime -= Time.deltaTime;
            int displayTime = Mathf.CeilToInt(currentTime);
            countdownText.text = displayTime.ToString();

            if (displayTime <= 4)
            {
                internalCamera.enabled = false;
                externalCamera.enabled = true;
            }

            if (currentTime <= 0)
            {
                countdownText.text = "!";
                countdownActive = false;
                currentTime = -1;
                // 여기서 발사 관련 추가 행동을 구현할 수 있습니다.
            }
        }
    }

    // 버튼 클릭 시 호출될 함수
    public void StartCountdown()
    {
        currentTime = countdownTime;
        countdownActive = true;
    }
}
