using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class breathingZone : MonoBehaviour
{
    public bool isBreathing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        // if the controller is the left hand
        if (other.CompareTag("GameController") && isBreathing)
        {
            Debug.Log("VIBRATING");
            var xrController = other.GetComponent<XRBaseController>();
            if (xrController != null)
            {
                xrController.SendHapticImpulse(0.5f, 0.5f);
            }
            else
            {
                Debug.Log("ERROR: WRONG CONTROLLER");
            }
        }


    }
}
