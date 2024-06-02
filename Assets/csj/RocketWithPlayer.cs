using UnityEngine;

public class RocketWithPlayer : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform 참조

    void Start()
    {
        // 게임 시작 시 플레이어를 로켓에 탑승시키는 로직
        BoardPlayer();
    }

    // 플레이어를 로켓에 탑승시키는 메서드
    public void BoardPlayer()
    {
        // 플레이어의 Transform을 로켓의 자식으로 설정
        playerTransform.parent = transform;
    }

    void Update()
    {
        // 여기에 로켓을 전진시키는 코드 추가
    }
}
