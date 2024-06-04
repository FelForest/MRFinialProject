using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class VignetteToggle : MonoBehaviour
{
    public PostProcessVolume volume;
    public Image blackoutImage;  // 블랙아웃 이미지를 연결할 변수
    private Vignette vignette;
    private bool isVignetteActive = false;

    public GameObject fade;

    void Start()
    {
        // Vignette 효과를 프로파일에서 찾기
        if (volume != null && volume.profile != null)
        {
            volume.profile.TryGetSettings(out vignette);

            if (vignette != null)
            {
                vignette.active = false; // 초기에는 비네팅 비활성화
            }
            else
            {
                Debug.LogError("Vignette 효과를 프로파일에서 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("PostProcessVolume 또는 프로파일이 할당되지 않았습니다!");
        }

        if (blackoutImage != null)
        {
            blackoutImage.gameObject.SetActive(false);  // 초기에는 블랙아웃 이미지 비활성화
        }
    }

    void Update()
    {
        // 'E' 키 입력 체크
        if (Input.GetKeyDown(KeyCode.E))
        {
            fade.GetComponent<Fade>().FadeStart();
            if (vignette != null)
            {
                StartCoroutine(ToggleVignetteWithBlackout());
            }
        }
    }

    private IEnumerator ToggleVignetteWithBlackout()
    {
        yield return new WaitForSeconds(0.5f);
        isVignetteActive = !isVignetteActive;  // 비네팅 활성/비활성 토글
        vignette.active = isVignetteActive;
    }
}
