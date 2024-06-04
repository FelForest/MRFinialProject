using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    public FadeType currentType = FadeType.Normal;

    public float fadeTime = 0.5f;
    public float durationTime = 0.5f;

    CanvasGroup canvasGroup;

    

    public enum FadeType
    {
        In,
        Out,
        Normal
    }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void FadeStart()
    {
        StartCoroutine(FadeCorutine());
    }

    IEnumerator FadeCorutine()
    {
        switch (currentType)
        {
            case FadeType.Out:
                yield return StartCoroutine(FadeOut());
                break;
            case FadeType.In:
                yield return StartCoroutine(FadeIn());
                break;
            case FadeType.Normal:
                yield return StartCoroutine(FadeOut());
                yield return new WaitForSeconds(durationTime);
                yield return StartCoroutine(FadeIn());
                break;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0.0f;
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1.0f;
    }
}
