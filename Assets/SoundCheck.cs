using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{
    public AudioClip correctSound; 
    public AudioClip wrongSound;
    public AudioSource firstAidSpeaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("firstAidKitElement"))
        {
            if (firstAidSpeaker != null)
            {
                firstAidSpeaker.clip = correctSound;
                firstAidSpeaker.Play();
            } 
        } else if (other.CompareTag("wrongFirstAid"))
        {
            if (firstAidSpeaker != null)
            {
                firstAidSpeaker.clip = wrongSound;
                firstAidSpeaker.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
