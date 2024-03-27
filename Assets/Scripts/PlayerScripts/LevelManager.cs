using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;
    public GameObject spawnPoint;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void LoadThisScene(string sceneName)
    {
        if(sceneName == "DemoAI")
        {
            player.GetComponent<FPS>().AIHUD.SetActive(true);
        }
        else
        {
            player.GetComponent<FPS>().AIHUD.SetActive(false);
        }
        if(sceneName.StartsWith("Demo"))
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
        }
        SceneManager.LoadScene(sceneName);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        spawnPoint = GameObject.FindWithTag("PlayerSpawner");
        player.transform.position = spawnPoint.transform.position;
    }
}
