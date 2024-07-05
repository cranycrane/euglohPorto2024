using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class breathingZone : MonoBehaviour
{
    [SerializeField]
    XRBaseController rightController;

    [SerializeField]
    XRBaseController leftController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if the controller is the left hand
        if (other.CompareTag("leftController") && GlobalVariables.isBreathing)
        {
            SendLeftHapticsImpulse(0.5f);
        }

    

        // if the controller is the right hand
        if (other.CompareTag("rightController") && GlobalVariables.isBreathing)
        {
            SendRightHapticsImpulse(0.5f);
        }


    }

    void SendRightHapticsImpulse(float duration)
    {
        if (rightController == null)
        {
            rightController.SendHapticImpulse(0.5f, duration);
        }
    }

    void SendLeftHapticsImpulse(float duration)
    {
        if (leftController != null)
        {
            leftController.SendHapticImpulse(0.5f, duration);
        }
    }
}
