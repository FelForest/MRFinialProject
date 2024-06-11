using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class BoardingFade : MonoBehaviour
{
    public  GameObject Fade; 
    

    void Update()
    {
        // 'Q' 키 입력 체크
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fade.GetComponent<Fade>().FadeStart();    
            
        }
    }
    
}
