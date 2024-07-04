using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillation : MonoBehaviour
{
    public float amp;
    public float frequency;
    private float initialHeight;

    private void Start()
    {
        initialHeight = transform.position.y;
    }

    // Update is called once per frame
    private void Update() 
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * frequency) * amp + initialHeight , transform.position.z);
    }
}
