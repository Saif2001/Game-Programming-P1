using UnityEngine;
using UnityEngine.UI;

public class DamageHealth : MonoBehaviour
{   

    public float health = 50f;
    public float damage = 5f;

    //Enemy health and weapon damage

    public Transform Player;


    void OnTriggerEnter(Collider other)     //Enemies are convex triggers - this function will actuate when a collider passes through trigger zone
    {
        TakeDamage(damage);
    }

    public void TakeDamage(float damage) { 
        health -= damage;               //Decrement enemy health by weapon damage
        Debug.Log("Target health: " + health);
        if(health <= 0f)
        {
            Die();
            Weapon player = Player.GetComponent<Weapon>();
            player.kills++;     //Increment kills for use in next level function (All enemies must be killed to progress)

            
        }
    }

    void Die()
    {
        Destroy(gameObject);        //Kill enemy with health < 0
    }



}
