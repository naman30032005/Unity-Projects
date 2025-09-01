using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    private bool isOpen = false;
    private bool isPlayerInside = false;
    private float exitDelay = 3f;
    private float exitTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerInside)
        {
            exitTimer += Time.deltaTime;

            if (exitTimer >= exitDelay && isOpen)
            {
                Debug.Log("Closing door");
                doorAnimator.ResetTrigger("Door_Open");
                doorAnimator.Play("Door_Close", 0, 0f);
                doorAnimator.SetTrigger("Door_Close");
                isOpen = false;
            }
        }
        else
        {
            exitTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            isPlayerInside = true;
            exitTimer = 0f;
            if (doorAnimator != null && !isOpen)
            {
                doorAnimator.ResetTrigger("Door_Close");
                doorAnimator.Play("Door_Open", 0, 0f);
                doorAnimator.SetTrigger("Door_Open");
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            exitTimer = 0f;
        }
    }
}
