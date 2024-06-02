using UnityEngine;

public class RocketFront : MonoBehaviour
{
    public float speed = 5f; // 로켓의 이동 속도
    public Transform player; // 플레이어의 Transform

    void Start()
    {
        // 게임 시작 시 플레이어를 로켓의 자식 오브젝트로 설정합니다.
        if (player != null)
        {
            player.SetParent(transform);
        }
    }

    void Update()
    {
        // 매 프레임마다 로켓을 앞으로 이동시킵니다.
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
