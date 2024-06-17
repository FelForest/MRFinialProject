using UnityEngine;

public class RocketMoveOnExternalCamera : MonoBehaviour
{
    public float speed = 5f; // 로켓의 이동 속도
    public Camera externalCamera; // 외부 카메라

    void Update()
    {
        // 외부 카메라가 활성화되어 있을 때만 로켓을 이동시킵니다.
        if (externalCamera != null && externalCamera.enabled)
        {
            // 로켓을 z축 방향으로 이동시킵니다.
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }
}
