using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
    public Camera interiorCamera;
    public Camera exteriorCamera;
    public GameObject[] fuelTanks; // 여러 개의 연료 탱크를 관리하기 위해 배열 사용
    public float detachForce = 500f;
    public float rocketThrust = 1000f;

    private Rigidbody rocketRigidbody;

    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MoveRocketForward());
        
        interiorCamera.gameObject.SetActive(true);
        exteriorCamera.gameObject.SetActive(false);
    }

    IEnumerator MoveRocketForward()
    {
        while (true)
        {
            rocketRigidbody.AddForce(transform.forward * rocketThrust * Time.deltaTime);
            yield return null;
        }
    }

    public void DetachButtonPressed()
    {
        if (interiorCamera != null && exteriorCamera != null)
        {
            interiorCamera.gameObject.SetActive(false);
            exteriorCamera.gameObject.SetActive(true);
        }

        // 모든 연료 탱크에 대해 반복 작업 수행
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
}
