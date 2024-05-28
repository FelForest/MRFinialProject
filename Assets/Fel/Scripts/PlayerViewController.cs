using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour
{
    public float sensitivity = 500.0f;
    private Vector2 viewPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ViewPointSet();
    }

    void ViewPointSet()
    {
        // Get the Mouse movement 
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Debug.Log(mouseY);

        // Change viewpoint
        viewPoint.x -= mouseY * sensitivity * Time.deltaTime;
        viewPoint.y += mouseX * sensitivity * Time.deltaTime;

        // Limit the viewpoint
        viewPoint.x = Mathf.Clamp(viewPoint.x, -35.0f, 30.0f);
        //viewPoint.y = Mathf.Clamp(viewPoint.y, -50.0f, 50.0f);

        // Set the player and eyes(cam) rotation
        //transform.rotation = Quaternion.Euler(0, viewPoint.y, 0);
        transform.localEulerAngles = new Vector3(viewPoint.x, viewPoint.y, 0);
    }
}
