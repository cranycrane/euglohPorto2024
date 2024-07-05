using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHitScriptTrigger : MonoBehaviour
{
    public GameObject Pedestrian;
    private bool hasPlayed = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENTERED");
        }
        Debug.Log("HIT CAR ANIMATION " + other.ToString());
    }
}
