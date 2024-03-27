using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public enum GameState{ Gameplay, Paused, GameOver}
    public GameState gameState;
    public LevelManager levelManager;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void GamePlay()
    {
        if(player.activeSelf != true)
        {
            player.SetActive(true);
        }
    }
    public void GameOver()
    {
        if(player.activeSelf == true)
        {
            levelManager.LoadThisScene("Death");
            player.SetActive(false);
        }
    }
    void Update()
    {
        switch(gameState)
        {
            case GameState.Gameplay: GamePlay(); break;
            case GameState.GameOver: GameOver(); break;
        }
    }
}
