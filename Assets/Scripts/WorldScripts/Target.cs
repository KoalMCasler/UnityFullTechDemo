using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource targetSFX;
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            targetSFX.Play();
            this.gameObject.SetActive(false);
        }
    }
}
