using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    private float countdownTime = 10f;
    private bool isLaunching = false;

    void Update()
    {
        if (isLaunching)
        {
            countdownTime -= Time.deltaTime;
            int displayTime = Mathf.CeilToInt(countdownTime);
            countdownText.text = displayTime.ToString();

            if (countdownTime <= 5f)
            {
                countdownText.color = Color.red;
            }

            if (countdownTime <= 0f)
            {
                Launch();
            }
        }
    }

    public void StartCountdown()
    {
        isLaunching = true;
    }

    private void Launch()
    {
        Debug.Log("Launch!");
        SceneManager.LoadScene("LaunchScene"); // 발사 씬으로 전환
    }
}