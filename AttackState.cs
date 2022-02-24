using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : States
{


    private void Start()
    {
    }

    public IdleState idleState;

    public Transform Enemy;
    public Transform Player;


    public Transform EnemyBulletSpawn;
    public GameObject Enemy_Bullet;

    private bool readyToFire = false;

    private bool playerInRange;
    private bool playerTooFar;
    private float reloadTime = 3f;

    public float bulletForce = 20f;


    public override States RunCurrentState()
    {
        if (Vector3.Distance(Player.position, transform.position) > 5) {
        Enemy.LookAt(Player.position);
        Enemy.Translate(Vector3.forward * 0.05f);
        }

        if (Vector3.Distance(Player.position, Enemy.position) < 60)
        {
            playerInRange = true;
        }
        else if(Vector3.Distance(Player.position, Enemy.position) > 80)
        {
            playerInRange = false;
            playerTooFar = true;
        }
        else
        {
            playerInRange = false;
            playerTooFar = false;
        }

        //enemyFire();

        if (playerInRange)
        {
            readyToFire = true;
            InvokeRepeating("enemyFire", 0, 1);
            return this;
        }
        if (playerTooFar)
        {
            Debug.Log("PLAYER TOO FAR");
            return idleState;
        }
        else { 
            Debug.Log("Just following, no attack"); 
            return this; 
        }



    }


    void enemyFire()
    {
        Vector3 bulletDirection = Player.position - EnemyBulletSpawn.position;

        reloadTime -= Time.deltaTime;
        if(readyToFire == true && reloadTime <= 0) { 
        GameObject enemyBullet = Instantiate(Enemy_Bullet, EnemyBulletSpawn.position, Quaternion.identity);
        enemyBullet.transform.forward = bulletDirection.normalized;
        enemyBullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * bulletForce, ForceMode.Impulse);

        readyToFire = false;
        //Debug.Log("FIRING");
        reloadTime = 3f;
        }

        

    }

 

}
