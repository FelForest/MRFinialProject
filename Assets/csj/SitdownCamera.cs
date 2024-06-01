using UnityEngine;
using System.Collections;

public class SitdownCamera : MonoBehaviour
{
    public Transform targetPosition; // 목표 위치
    public float moveDuration = 2.0f; // 이동 시간
    public float startYOffset = -0.5f; // 초기 Y 오프셋 (앉는 느낌)

    private Vector3 initialPosition;
    private Vector3 startPosition;

    void Start()
    {
        initialPosition = transform.position; // 현재 카메라 위치 저장
        startPosition = new Vector3(initialPosition.x, initialPosition.y + startYOffset, initialPosition.z); // 앉는 위치 설정
        transform.position = startPosition; // 카메라를 앉는 위치로 설정

        StartCoroutine(MoveCameraToInitialPosition());
    }

    IEnumerator MoveCameraToInitialPosition()
    {
        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition; // 최종 위치로 설정
    }
}
