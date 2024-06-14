using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAUdioController : MonoBehaviour
{

    public AudioSource audio;

    private void Awake()
    {
        if(audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
    }
    
    public void PlaySFX()
    {
        audio.Play();
    }

}
