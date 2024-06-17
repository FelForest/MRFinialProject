using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class RocketLauncher : MonoBehaviour
{
    public float launchForce = 1000f; // 발사 힘
    public float continuousForce = 30f; // 지속적인 상승 힘
    private Rigidbody rocketRigidbody;
    private bool isLaunched = false;
    private Vector3 initialPosition;

    public GameObject[] fuelTanks; // 여러 개의 연료 탱크를 관리하기 위해 배열 사용
    public float detachForce = 500f;
    public float detachTime = 5.0f;
    public float nextSceneTime = 2.0f;

    public Fade fade;
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
        Invoke(nameof(DetachTank), detachTime);
        Invoke(nameof(NextScene), detachTime + nextSceneTime);
    }

    void DetachTank(){
        foreach (GameObject fuelTank in fuelTanks)
        {
            if (fuelTank != null)
            {
                fuelTank.transform.parent = null;
                Rigidbody tankRigidbody = fuelTank.GetComponent<Rigidbody>();
                if (tankRigidbody == null)
                {
                    tankRigidbody = fuelTank.AddComponent<Rigidbody>(); // Rigidbody 컴포넌트가 없다면 추가
                }
                    // 연료 탱크에 무작위 방향의 힘을 추가
                Vector3 randomDirection = Random.onUnitSphere * detachForce;
                tankRigidbody.AddForce(randomDirection, ForceMode.Impulse);
                
                // 연료 탱크에 무작위 회전력을 추가
                Vector3 randomTorque = Random.insideUnitSphere * detachForce;
                tankRigidbody.AddTorque(randomTorque, ForceMode.Impulse);
            }
        }
    }

    void SceneLoad()
    {
        SceneManager.LoadScene("Space");
    }
    void NextScene()
    {
        fade.FadeStart();
        Invoke(nameof(SceneLoad), fade.fadeTime);
    }
}
