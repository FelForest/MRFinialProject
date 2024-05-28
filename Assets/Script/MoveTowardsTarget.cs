using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public Transform target; // 물체 A의 Transform을 할당
    public float speed = 2.0f; // 이동 속도

    void Update()
    {
        if (target != null)
        {
            //obj B-> obj A 방향으로 이동
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
