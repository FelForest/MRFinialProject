using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneDestroy : MonoBehaviour
{
    public GameObject objectToDestroy; // 없어질 오브제

    // 트리거 존에 진입했을 때 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했을 때만 실행
        {
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy); // 오브제 삭제
            }
            
        }
    }
}
