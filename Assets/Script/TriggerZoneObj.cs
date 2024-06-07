using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneObj : MonoBehaviour
{
    public GameObject objectToSpawn; // 스폰될 오브제

    // 트리거 존에 진입했을 때 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했을 때만 실행
        {
            if (objectToSpawn != null)
            {
                objectToSpawn.SetActive(true); // 오브제 활성화
            }
            else
            {
                Debug.LogWarning("스폰할 오브젝트가 설정되지 않았습니다.");
            }
        }
    }
}
