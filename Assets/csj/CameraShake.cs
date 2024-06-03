using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float m_roughness = 1.0f;      // 거칠기 정도
    [SerializeField]
    private float m_magnitude = 0.1f;      // 움직임 범위

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(ContinuousShake());
    }

    private IEnumerator ContinuousShake()
    {
        while (true)
        {
            float tick = Random.Range(-10f, 10f);

            tick += Time.deltaTime * m_roughness;
            transform.localPosition = new Vector3(
                originalPosition.x + (Mathf.PerlinNoise(tick, 0) - 0.5f) * m_magnitude,
                originalPosition.y + (Mathf.PerlinNoise(0, tick) - 0.5f) * m_magnitude,
                originalPosition.z); // originalPosition.z를 유지하여 z 위치가 변하지 않도록 함

            yield return null;
        }
    }
}
