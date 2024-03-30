using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
