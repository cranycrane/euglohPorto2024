using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("SnapObj")) {
            return;
        }

        // get the transform of the object
        other.transform.position = transform.position;
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
