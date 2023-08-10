using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionSound : MonoBehaviour
{
    private AudioSource auds;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            Debug.Log("adio");
            auds.Play();
        }
        
    }
}
