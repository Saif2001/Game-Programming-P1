using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDied : MonoBehaviour
{

    public GameObject Player;   //Instantiating objects to get player health and death animator
    public Animator Death;

    // Update is called once per frame
    void Update()
    {
        Weapon player = Player.GetComponent<Weapon>();      
        float playerHealth = player.health;             //Keep updated player health

        if(playerHealth <= 0)
        {
            LoadDeathScreen();              //Animation to kill player
        }
    }

    public void LoadDeathScreen()
    {
        Death.SetTrigger("Died");           //Trigger to set animation
    }
}
