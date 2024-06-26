using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCannon : MonoBehaviour
{
    public GameObject armCannon;
    public GameObject projectile;
    private GameObject bullet;
    private Rigidbody bulletRB;
    public int BulletForce;
    public bool bulletIsAlive;
    public Quaternion bulletRotation;
    private Transform playerTransform;
    private GameObject player;
    private FPS playerFPS;
    public bool armCannonIsActive;
    public AudioSource gunSFX;
    void Start()
    {
        armCannonIsActive = false;
        player = GameObject.FindWithTag("Player");
        playerTransform = this.GetComponent<Transform>();
        playerFPS = player.GetComponent<FPS>();
        if(BulletForce <= 1)
        {
            BulletForce = 2;
        }

    }
    void OnFire()
    {
        if(playerFPS.inputIsEnalbled && armCannonIsActive)
        {
            if(bulletIsAlive != true)
            {
                gunSFX.Play();
                bulletIsAlive = true;
                bullet = GameObject.Instantiate(projectile, armCannon.transform.position,bulletRotation);
                bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.AddForce(armCannon.transform.up*BulletForce, ForceMode.Impulse);
            }
            else
            {
                Destroy(bullet);
            }    
        }
    }
    void Update()
    {
        bulletRotation = playerTransform.rotation;
    }
    public void BulletIsDestroyed()
    {
        bulletIsAlive = false;
    }

}
