using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenEKeyPressed : MonoBehaviour
{
    public GameObject objectToDestroy;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }
}
