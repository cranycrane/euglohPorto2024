using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHitScriptTrigger : MonoBehaviour
{
    public GameObject Car;
    private bool hasPlayed = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            Animator carAnimator = Car.GetComponentInChildren<Animator>();
            carAnimator.SetTrigger("StartCar");
            ParticleSystem blood = Car.GetComponentInChildren<ParticleSystem>();
            blood.Play();
            
            Debug.Log("PLAYER ENTERED");
        }
        Debug.Log("HIT CAR ANIMATION " + other.ToString());
    }
}
