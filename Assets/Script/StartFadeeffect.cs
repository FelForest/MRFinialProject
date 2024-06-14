using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class StartFadeeffect : MonoBehaviour
{
    public  GameObject Fade; 
    
    void Start()
    {
        Fade.GetComponent<Fade>().FadeStart();   
    }
    void Update()
    {
        
    }
    
}
