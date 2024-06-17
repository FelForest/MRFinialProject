using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProximityCheck : MonoBehaviour
{
    public Transform target; // Object A의 Transform
    public Button actionButton; // Button 참조

    private void Start()
    {
        // Start 로그 메시지 추가
        Debug.Log("Start method called");

        // 버튼을 비활성화
        actionButton.gameObject.SetActive(false);

        // 버튼에 클릭 이벤트 추가
        actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("Button clicked, loading new scene...");
        //SceneManager.LoadScene("Landing"); // 변경하려는 Scene 이름으로 교체
    }

    private void OnTriggerEnter(Collider other)
    {
        // OnTriggerEnter 로그 메시지 추가
        Debug.Log("OnTriggerEnter with: " + other.name);

        if (other.transform == target)
        {
            Debug.Log("Target entered trigger");
            if (!actionButton.gameObject.activeSelf)
            {
                Debug.Log("Activating button");
                actionButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // OnTriggerExit 로그 메시지 추가
        Debug.Log("OnTriggerExit with: " + other.name);

        if (other.transform == target)
        {
            Debug.Log("Target exited trigger");
            if (actionButton.gameObject.activeSelf)
            {
                Debug.Log("Deactivating button");
                actionButton.gameObject.SetActive(false);
            }
        }
    }
}
