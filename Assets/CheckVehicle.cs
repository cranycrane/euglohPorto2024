using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVehicle : MonoBehaviour
{
    public Animator pedestrian;
    public Transform vehicle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool hit = false;

    // Update is called once per frame
    void Update()
    {
        if (hit) {return;}

        if (Vector3.Distance(vehicle.position, transform.position) < 0.01f) { 
            hit = true;
            Debug.Log("Killllll");
            pedestrian.SetTrigger("Kill");
        } 
    }
}
