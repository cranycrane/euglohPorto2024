using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class breathingZone : MonoBehaviour
{
    public bool isBreathing = false;
    public bool isVibrating = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        // if the controller is the left hand
        if (other.CompareTag("GameController") && isBreathing)
        {
            Debug.Log("VIBRATING");
            isVibrating = true;
            var xrController = other.GetComponent<HapticImpulsePlayer>();
            if (xrController != null)
            {
                while (isVibrating)
                {

                    xrController.SendHapticImpulse(0.6f, 0.3f);

                    yield return new WaitForSeconds(0.8f);
                }
            }
            else
            {
                Debug.Log("ERROR: WRONG CONTROLLER");
            }

        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            isVibrating = false;
        }
    }
}