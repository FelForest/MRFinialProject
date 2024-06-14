using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    public GameObject ending;
    public GameObject PPV;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ending.SetActive(true);
            Destroy(PPV);
            Destroy(gameObject);
        }
    }
}
