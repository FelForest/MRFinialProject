using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SetGravity : MonoBehaviour
{

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -1.68f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
