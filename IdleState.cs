using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : States
{
    public Transform Player;
    public Transform Enemy;

    private bool playerSeen;
    private bool raycastHitObject;
    public FollowPlayerState followPlayerState;

    private void OnDrawGizmos()
    {
       Gizmos.DrawRay(transform.position, Enemy.forward * 100);

        Gizmos.DrawRay(transform.position, (Quaternion.Euler(0, 35, 0) * Enemy.forward) * 100);
        Gizmos.DrawRay(transform.position, (Quaternion.Euler(0, 55, 0) * Enemy.forward) * 100);
        Gizmos.DrawRay(transform.position, (Quaternion.Euler(0, 75, 0) * Enemy.forward) * 100);

       Gizmos.DrawRay(transform.position, (Quaternion.Euler(0, -35, 0) * Enemy.forward) * 100) ;
       Gizmos.DrawRay(transform.position, (Quaternion.Euler(0, -55, 0) * Enemy.forward) * 100);
       Gizmos.DrawRay(transform.position, (Quaternion.Euler(0, -75, 0) * Enemy.forward) * 100);
        //Gizmos.DrawRay(transform.position, Enemy.forward * 100);

    }

    // Start is called before the first frame update
    public override States RunCurrentState()
    {
        RaycastHit hitCenter;
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit hit4;
        RaycastHit hit5;
        RaycastHit hit6;
        RaycastHit hit7;


        if (Physics.Raycast(Enemy.position, Enemy.forward, out hitCenter, 100) && hitCenter.transform.tag == "Player")
        {
            playerSeen = true;
        }
        else if(Physics.Raycast(Enemy.position, (Quaternion.Euler(0, 35, 0) * Enemy.forward), out hit2, 100) && hit2.transform.tag == "Player")
        {
            playerSeen = true;
        }
        else if(Physics.Raycast(Enemy.position, (Quaternion.Euler(0, 55, 0) * Enemy.forward), out hit3, 100) && hit3.transform.tag == "Player")
        {
            playerSeen = true;
        }
        else if (Physics.Raycast(Enemy.position, (Quaternion.Euler(0, 75, 0) * Enemy.forward), out hit4, 100) && hit4.transform.tag == "Player")
        {
            playerSeen = true;
        }

        else if (Physics.Raycast(Enemy.position, (Quaternion.Euler(0, -35, 0) * Enemy.forward), out hit5, 100) && hit5.transform.tag == "Player")
        {
            playerSeen = true;
        }
        else if (Physics.Raycast(Enemy.position, (Quaternion.Euler(0, -55, 0) * Enemy.forward), out hit6, 100) && hit6.transform.tag == "Player")
        {
            playerSeen = true;
        }
        else if (Physics.Raycast(Enemy.position, (Quaternion.Euler(0, -75, 0) * Enemy.forward), out hit7, 100) && hit7.transform.tag == "Player")
        {
            playerSeen = true;
        }
        


        else
        {
            playerSeen = false;
            //Debug.Log("Lost sight of player");
        }
        
        if (playerSeen)
        {
        return followPlayerState;
        }

        else
        {
            return this;
        }

    }
}
