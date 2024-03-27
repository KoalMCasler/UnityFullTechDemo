using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Game object used to take the transform of teleport destination
    [SerializeField]
    private GameObject currentTeleport;
    [SerializeField]
    public GameObject activeCheckpoint;
    public GameObject PrevCheckpoint;
    public float TransitionTime = 0.3f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject playerSpawnPosition; 
    public PlayerController playerController; 
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerSpawnPosition = GameObject.FindWithTag("PlayerSpawner");
    }
    // Input check
    void Update()
    {
    //     if (Input.GetButtonDown("Interact"))
    //     {
    //         StartCoroutine(Teleport());
    //     }
    }

    private void OnTriggerEnter(Collider other)
    {
        // grabs destination on entering location of tagged object.
        if (other.CompareTag("Checkpoint"))
        {
            if(other != activeCheckpoint && activeCheckpoint != null)
            {
                PrevCheckpoint = activeCheckpoint;
            }
            activeCheckpoint = other.gameObject;
            PrevCheckpoint.GetComponent<Checkpoint>().IsActiveCheckpoint = false;
            activeCheckpoint.GetComponent<Checkpoint>().IsActiveCheckpoint = true;   
        }
        if (other.CompareTag("KillBox"))
        {
            Debug.Log("Player touched kill box");
            currentTeleport = playerSpawnPosition;
            playerController.health = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // nulls destination on exit of area to prevent teleport when not over object
        if (other.CompareTag("Teleport"))
        {
            if (other.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }
    // Coroutine used to delay teleport only after transition effect is started 
    private IEnumerator Teleport()
    {
        // uses destination from DoorTP script to move player
        if (currentTeleport != null)
            {
                //transition.SetBool("Start", true);
                yield return new WaitForSeconds(TransitionTime);
                player.transform.position = (currentTeleport.GetComponent<Teleport>().GetDestination().position);
                //transition.SetBool("Start", false);
            }
    }
    private IEnumerator CheckpointSpawn()
    {
        // uses destination from DoorTP script to move player
        if (activeCheckpoint != null)
            {
                //transition.SetBool("Start", true);
                yield return new WaitForSeconds(TransitionTime);
                player.transform.position = (activeCheckpoint.GetComponent<Teleport>().GetDestination().position);
                //transition.SetBool("Start", false);
            }
            else
            {
                yield return new WaitForSeconds(TransitionTime);
                player.transform.position = (playerSpawnPosition.GetComponent<Teleport>().GetDestination().position);
            }
    }
    public void Respawn()
    {
        StartCoroutine(CheckpointSpawn());
    }
}
