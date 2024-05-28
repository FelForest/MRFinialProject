using UnityEngine;

public class AnimationAudioController : MonoBehaviour
{
    public AudioSource audioSource; // 재생할 오디오 소스
    public Animator animator; // 애니메이터 컴포넌트
    public string animationParameterName = "isWalking"; // 애니메이션 파라미터 이름

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource를 설정하지 않았습니다.");
        }

        if (animator == null)
        {
            Debug.LogError("Animator를 설정하지 않았습니다.");
        }
    }

    void Update()
    {
        // 애니메이션 파라미터 값 가져오기
        bool isAnimationPlaying = animator.GetBool(animationParameterName);

        if (isAnimationPlaying)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // 애니메이션이 실행 중이면 오디오 재생
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // 애니메이션이 멈추면 오디오 중지
            }
        }
    }
}
