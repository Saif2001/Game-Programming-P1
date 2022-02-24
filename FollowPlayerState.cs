using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerState : States
{

    public AttackState attackState;
    private bool playerInRange;
    public Transform Player;
    public Transform Enemy;     //Necessary transforms to follow player

    public float range = 30f;

    // Start is called before the first frame update
    public override States RunCurrentState()
    {
        if (!playerInRange && Vector3.Distance(Player.position, transform.position) > 5)        //Following logic
        {
            Enemy.LookAt(Player.position);
            Enemy.Translate(Vector3.forward * 0.3f);                                        //Lock onto and follow player
        }

        if (Vector3.Distance(Player.position, transform.position) < range)
        {
            playerInRange = true;                                       //In small enough range, switch to attack
        }



        if (playerInRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }

    }
}
