using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Ending : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private bool isEnding = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isEnding)
            {
                isEnding = true;
                EndingStart();
            }
            
        }
    }

    private void EndingStart()
    {
        //시네머신 쪽은 아직 잘 모름 일단 해보겠음
    }
}
