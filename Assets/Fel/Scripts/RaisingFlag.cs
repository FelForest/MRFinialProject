using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingFlag : MonoBehaviour
{
    bool isRaised = false;
    public Animator animator;
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
}
