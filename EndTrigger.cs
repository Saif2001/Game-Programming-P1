using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    private int killCounter;

    int botsKilledFromScript;       //Need to kill all bots to proceed

    public bool readyToTransition = false;      //Fires when conditions are correct to continue

    private void Update()
    {
        GameObject Player = GameObject.Find("Player");  
        Weapon player = Player.GetComponent<Weapon>();
        botsKilledFromScript = player.kills;                //Retrieving and updating player's kills
    }
    private void OnTriggerEnter(Collider other)
    {
        //Separate functions for different levels
        if (SceneManager.GetActiveScene().buildIndex == 0)         //If in scene 1 AND has killed 10 bots (all in scene 1) then proceed
        {
            if (botsKilledFromScript == 10)
            {
                Debug.Log("LEVEL FINISHED");
                LoadLevels newLevel = GameObject.Find("End Trigger").GetComponent<LoadLevels>();
                readyToTransition = true;
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)           //If in scene 2 AND has killed 5 bots (all in scene 2) then proceed
            if (botsKilledFromScript == 5)
            {
                Debug.Log("LEVEL FINISHED");
                LoadLevels newLevel = GameObject.Find("End Trigger 2").GetComponent<LoadLevels>();
                readyToTransition = true;
            }
    }
}
