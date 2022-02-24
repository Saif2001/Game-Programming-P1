using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public GameObject Player;


    // Attached to enemy bullet and will damage player
    void OnTriggerEnter(Collider other)
    {
        //Decrement Health
        if (other.tag == "Player")
        {
            Weapon player = Player.GetComponent<Weapon>();
            player.health = player.health - 10;

        }
    }

}
