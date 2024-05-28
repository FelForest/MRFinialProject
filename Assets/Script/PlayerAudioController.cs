using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource walkingAudioSource; // 걷는 소리 오디오 소스

    private Rigidbody rb;
    private Vector3 previousPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody 컴포넌트를 찾을 수 없습니다.");
        }

        if (walkingAudioSource == null)
        {
            Debug.LogError("Walking AudioSource를 설정하지 않았습니다.");
        }

        previousPosition = transform.position;
    }

    void Update()
    {
        // 좌우 및 앞뒤 이동을 감지
        float horizontalMovement = Mathf.Abs(transform.position.x - previousPosition.x);
        float verticalMovement = Mathf.Abs(transform.position.z - previousPosition.z);

        if (horizontalMovement > 0.01f || verticalMovement > 0.01f) // 일정 값 이상 움직임이 있을 때만 재생
        {
            if (!walkingAudioSource.isPlaying)
            {
                walkingAudioSource.Play(); // 플레이어가 움직이면 오디오 재생
            }
        }
        else
        {
            if (walkingAudioSource.isPlaying)
            {
                walkingAudioSource.Stop(); // 플레이어가 멈추면 오디오 중지
            }
        }

        // 이전 위치 갱신
        previousPosition = transform.position;
    }
}
