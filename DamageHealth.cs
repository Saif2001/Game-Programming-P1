
using UnityEngine;

public class DamageHealth : MonoBehaviour
{

    public float health = 50f;

    public void TakeDamage(float amount) { 
        health -= amount;
        Debug.Log("Target health: " + health);
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }



}
