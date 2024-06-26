using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;


public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthHUDObject;
    public TextMeshProUGUI livesHUDObject;
    public TextMeshProUGUI coinsHUDObject;
    private string healthText;
    private string livesText;
    private string coinsText;
    private GameObject player;
    //private Rigidbody playerRB;
    //public GameObject PlayerSpawner;
    public int health;
    public int lives;
    public int conins;
    public LevelManager levelManager;
    public GameManager gameManager;
    //private Transform reSpawnTransform;
    // Start is called before the first frame update
    void Awake()
    {
        health = 10;
        lives = 3;
        player = this.gameObject;
        //playerRB = this.GetComponent<Rigidbody>(); 
        //reSpawnTransform = this.transform;
        //PlayerSpawner = GameObject.FindWithTag("PlayerSpawner");
    }
    void Start()
    {
        
    }
    void Update()
    {
        HUDUpdate();
        if(health <= 0 && lives > 0)
        {
            Respawn();
        }
    }
    void Respawn()
    {
        player.GetComponent<PlayerTeleport>().Respawn();
        health = 10; 
        lives -= 1;
        if(lives <= 0)
        {
            gameManager.gameState = GameManager.GameState.GameOver;
        }
    }
    void HUDUpdate()
    {
        healthText = string.Format("HP = {0}",health);
        livesText = string.Format("Lives = {0}",lives);
        coinsText = string.Format("Coins = {0}",conins);
        healthHUDObject.text = healthText;
        livesHUDObject.text = livesText;
        coinsHUDObject.text = coinsText;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
