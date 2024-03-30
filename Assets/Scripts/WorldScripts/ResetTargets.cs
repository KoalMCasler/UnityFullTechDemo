using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTargets : MonoBehaviour
{
    public List<GameObject> targets;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            TargetReset();
        }
    }
    void TargetReset()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            targets[i].SetActive(true);
        }
    }
}
