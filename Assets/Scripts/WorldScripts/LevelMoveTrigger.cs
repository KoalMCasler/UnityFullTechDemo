using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelMoveTrigger : MonoBehaviour
{
    public string DesiredSceneName;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           GameObject levelManager = GameObject.Find("LevelManager");
           levelManager.GetComponent<LevelManager>().LoadThisScene(DesiredSceneName);
        }
    }
}
