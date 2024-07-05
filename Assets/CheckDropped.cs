using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDropped : MonoBehaviour
{
    public ElementChecking checking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enyeref box");
        // if other.cOMpareTag("box)
        checking.AddObject();

    }
}
