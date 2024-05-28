using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour
{
    bool isSpawn = false;
    public GameObject obj1;
    public GameObject obj2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSpawn)
            {
                obj1.SetActive(true);
                obj2.SetActive(true);
                isSpawn = true;
            }
        }
    }
}
