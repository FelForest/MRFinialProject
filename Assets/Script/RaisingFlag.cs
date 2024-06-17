using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisingFlag : MonoBehaviour
{
    bool isRaised = false;
    bool isPressed = false;
    bool isTrigger = false;
    public Animator animator;
    public GameObject Text;
    public GameObject nextObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isPressed)
            {
                isTrigger = true;
                Text.SetActive(true);
            }
        }
    }

    public void FlagRaised()
    {
        isRaised = true;
    }

    void Update() 
    {
        if(isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
            Text.SetActive(false);
            animator.enabled = true;
        }
        if(isRaised)
        {
            nextObject.SetActive(true);
            isRaised = false;
        }
    }
}
