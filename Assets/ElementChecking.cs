using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementChecking : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var kitObjects = GameObject.FindGameObjectsWithTag("firstAidKitElement");
        var wrongObjects = GameObject.FindGameObjectsWithTag("wrongFirstAid");
        var wrongCount = 0;
        var kitCount = 0;


        // Get the bounding box of the current object this script is attached to
        Collider boundingBoxCollider = GetComponent<Collider>();

        if (boundingBoxCollider != null)
        {
            Bounds boundingBox = boundingBoxCollider.bounds;

            foreach (var obj in kitObjects)
            {
                Collider objCollider = obj.GetComponent<Collider>();
                if (objCollider != null && boundingBox.Intersects(objCollider.bounds))
                {
                    kitCount++;
                }
            }

            foreach (var obj in wrongObjects)
            {
                Collider objCollider = obj.GetComponent<Collider>();
                if (objCollider != null && boundingBox.Intersects(objCollider.bounds))
                {
                    wrongCount++;
                }
            }

            // if the bounding box is complete
            if (kitCount == kitObjects.Length && wrongCount == 0)
            {
                textMeshProUGUI.text = "Kit status: Completed!!!";
                GlobalVariables.kitStatus = "completed";
            }
            // if the bounding box is incomplete
            if (kitCount < kitObjects.Length && wrongCount == 0)
            {
                textMeshProUGUI.text = "Kit status: Incomplete";
                GlobalVariables.kitStatus = "Kit status: incomplete";
            }
            // if intruder
            if (wrongCount > 0)
            {
                textMeshProUGUI.text = "You have an intruder!!!";
                GlobalVariables.kitStatus = "intruder";
            }


            // Use wrongCount for your logic
            Debug.Log("Number of wrong objects within the bounding box: " + wrongCount);
            Debug.Log("Number of right objects within the bounding box " + kitCount);

        }
        else
        {
            Debug.LogWarning("No Collider attached to the object this script is attached to.");
        }
    }

    public void AddObject()
    {
        // if correct number 
        textMeshProUGUI.text = "Whateber";
;
    }
}
