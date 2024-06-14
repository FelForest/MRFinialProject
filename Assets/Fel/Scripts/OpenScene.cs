using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScene : MonoBehaviour
{
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.GetComponent<Fade>().FadeStart();
        Destroy(gameObject, fade.GetComponent<Fade>().fadeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
