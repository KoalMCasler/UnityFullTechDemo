using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource coinSFX;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            coinSFX.Play();
            other.GetComponent<PlayerController>().conins += 1;
            this.gameObject.SetActive(false);
        }
    }
}
