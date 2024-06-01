using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public float launchForce = 1000f; // 발사 힘
    public float continuousForce = 30f; // 지속적인 상승 힘
    private Rigidbody rocketRigidbody;
    private bool isLaunched = false;
    private Vector3 initialPosition;

    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        rocketRigidbody.useGravity = false; // 시작할 때 중력 비활성화
        initialPosition = transform.position; // 초기 위치 저장
    }

    void FixedUpdate()
    {
        if (!isLaunched)
        {
            // 로켓의 위치를 초기 위치에 고정
            rocketRigidbody.velocity = Vector3.zero;
            transform.position = initialPosition;
        }
        else
        {
            // 로켓이 발사된 후 상승력 지속적으로 적용
            rocketRigidbody.AddForce(Vector3.up * continuousForce);
        }
    }

    public void Launch()
    {
        isLaunched = true;
        rocketRigidbody.useGravity = true; // 발사 직전에 중력 활성화
        rocketRigidbody.AddForce(Vector3.up * launchForce);
    }
}
