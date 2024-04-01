using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public AudioSource doorSFX;
    public Animator doorAnim;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorSFX.Play();
            doorAnim.SetBool("DoorIsOpen",true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorAnim.SetBool("DoorIsOpen",false);
        }
    }
}
