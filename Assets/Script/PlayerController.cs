using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    CharacterController controller;

    public float speed = 5f;

    public float mouseSensitivity = 2f;

    public Transform playerTransform;
    public Transform cameraTransform;

    float cameraxRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        PlayerMove();
        CameraLook();   
    }

    void PlayerMove()
    {
        float keyX = Input.GetAxis("Horizontal");
        float keyZ = Input.GetAxis("Vertical");

        Vector3 move = playerTransform.right * keyX + playerTransform.forward * keyZ;
        controller.Move(move * speed* Time.deltaTime);
    }

    void CameraLook()
    {
        float mouseX= Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY= Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraxRotation -= mouseY;
        cameraxRotation = Mathf.Clamp(cameraxRotation, -90f,90f);

        cameraTransform.localEulerAngles = Vector3.right * cameraxRotation;
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
