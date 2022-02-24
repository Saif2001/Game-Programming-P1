using UnityEngine;
using UnityEngine.UI;

public class DamageHealth : MonoBehaviour
{   

    public float health = 50f;
    public float damage = 5f;

    public Transform Player;


    void OnTriggerEnter(Collider other)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(float damage) { 
        health -= damage;
        Debug.Log("Target health: " + health);
        if(health <= 0f)
        {
            Die();
            Weapon player = Player.GetComponent<Weapon>();
            player.kills++;

            
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }



}
