using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource walkingAudioSource; // 걷는 소리 오디오 소스

    private Rigidbody rb;
    private Vector3 previousPosition;

    public Animator animator;

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

        if (animator == null)
        {
            Debug.LogError("Animator를 설정하지 않았습니다. ");
        }

        //previousPosition = transform.position;
    }

    void Update()
    {

        /*// 좌우 및 앞뒤 이동을 감지
        float horizontalMovement = Mathf.Abs(transform.position.x - previousPosition.x);
        float verticalMovement = Mathf.Abs(transform.position.z - previousPosition.z);

        //Debug.Log(horizontalMovement);
        //Debug.Log(verticalMovement);
        bool isMoving = (horizontalMovement > 0.01f || verticalMovement > 0.01f);

        Debug.Log(isMoving);
        if (isMoving)
        {
            if (!walkingAudioSource.isPlaying)
            {
                Debug.Log("움직임 감지 - 오디오 재생");
                walkingAudioSource.Play(); // 플레이어가 움직이면 오디오 재생
            }
        }
        else
        {
            if (walkingAudioSource.isPlaying)
            {
                Debug.Log("멈춤 감지 - 오디오 일시 중지");
                walkingAudioSource.Pause(); // 플레이어가 멈추면 오디오 일시 중지
            }
        }

        // 이전 위치 갱신
        previousPosition = transform.position;*/

        bool isMoving = animator.GetBool("isMoving");

        if (isMoving)
        {
            if (!walkingAudioSource.isPlaying)
            {
                Debug.Log("움직임 감지 - 오디오 재생");
                walkingAudioSource.Play();
            }
        }
        else
        {
            if (walkingAudioSource.isPlaying)
            {
                Debug.Log("멈춤 감지 - 오디오 일시 중지");
                walkingAudioSource.Pause();
            }
        }

    }
}
