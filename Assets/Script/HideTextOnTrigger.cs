using UnityEngine;
using UnityEngine.UI;

public class HideTextOnTrigger : MonoBehaviour
{
    public Text legacyText; // 화면에 띄울 텍스트 (Legacy UI)

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            legacyText.gameObject.SetActive(false);
        }
    }
}
