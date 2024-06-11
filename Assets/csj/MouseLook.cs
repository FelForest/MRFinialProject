using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // 위아래 각도 제한
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 10f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // 필요에 따라 수평 회전 활성화
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // playerBody.Rotate(Vector3.up * mouseX);
    }
}
