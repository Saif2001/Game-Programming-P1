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

    public float bulletForce = 50f;


    public override States RunCurrentState()
    {
        if (Vector3.Distance(Player.position, transform.position) > 5) {
        Enemy.LookAt(Player.position);
        Enemy.Translate(Vector3.forward * 0.02f);           //Following logic still necessary when attacking
        }

        if (Vector3.Distance(Player.position, Enemy.position) < 40)     //Shooting range. Players at a further distance than this will not get shot.
        {
            playerInRange = true;
        }
        else if(Vector3.Distance(Player.position, Enemy.position) > 60)     //Return to idle state; lost sight of player
        {
            playerInRange = false;
            playerTooFar = true;
        }
        else                                                                //Follow player, but they are too far to shoot at
        {
            playerInRange = false;
            playerTooFar = false;
        }

        //enemyFire();

        if (playerInRange)
        {
            readyToFire = true;
            InvokeRepeating("enemyFire", 0, 1);                             //Repeatedly shoot at player after "reload" intervals
            return this;
        }
        if (playerTooFar)                       //Switch to idle state in FSM
        {
            Debug.Log("PLAYER TOO FAR");
            return idleState;
        }
        else {                                      //Still in attack mode, using follow logic
            Debug.Log("Just following, no attack"); 
            return this; 
        }



    }


    void enemyFire()
    {
        Vector3 bulletDirection = Player.position - EnemyBulletSpawn.position;          //Position vector between Empty prefab and player location

        reloadTime -= Time.deltaTime;
        if(readyToFire == true && reloadTime <= 0) {                //Decrement time and only allow another shot if enough time has passed
        GameObject enemyBullet = Instantiate(Enemy_Bullet, EnemyBulletSpawn.position, Quaternion.identity);     //Spawn enemy's bullet
        enemyBullet.transform.forward = bulletDirection.normalized;                                     //Set forward direction as position vector to player
        enemyBullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * bulletForce, ForceMode.Impulse);        //Add force to imitate bullet

        readyToFire = false;
        //Debug.Log("FIRING");
        reloadTime = 3f;
        }

        

    }

 

}
