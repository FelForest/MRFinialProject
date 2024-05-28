using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownScript : MonoBehaviour
{
    public TMP_Text countdownText; // Countdown text
    public Camera internalCamera; // Internal camera
    public Camera externalCamera; // External camera

    private void Start()
    {
        // Activate internal camera, deactivate external camera at start
        internalCamera.enabled = true;
        externalCamera.enabled = false;

        countdownText.gameObject.SetActive(false); // Hide countdown text initially
    }

    public void StartCountdown()
    {
        countdownText.gameObject.SetActive(true); // Show countdown text when countdown starts
        StartCoroutine(Countdown(10)); // Start countdown from 10 seconds
    }

    private IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            countdownText.text = count.ToString(); // Update countdown text

            if (count == 4) // When 4 seconds remain
            {
                // Deactivate internal camera, activate external camera
                internalCamera.enabled = false;
                externalCamera.enabled = true;
            }

            yield return new WaitForSeconds(1); // Wait for 1 second
            count--; // Decrease countdown
        }

        countdownText.gameObject.SetActive(false); // Hide countdown text when it reaches 0
    }
}
