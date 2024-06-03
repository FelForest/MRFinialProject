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
        //�ó׸ӽ� ���� ���� �� �� �ϴ� �غ�����
    }
}
