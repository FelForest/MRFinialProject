using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingFlag : MonoBehaviour
{
    bool isRaised = false;
    public Animator animator;

    public GameObject nextObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isRaised)
            {
                animator.enabled = true;
            }
        }
    }

    public void FlagRaised()
    {
        isRaised = true;
    }

    void Update() 
    {
        if(isRaised)
        {
            nextObject.SetActive(true);
            isRaised = false;
        }
    }
}
