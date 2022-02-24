using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    private int killCounter;

    int botsKilledFromScript;

    public bool readyToTransition;

    // Start is called before the first frame update
    void Start()
    {
      //  GameObject Player = GameObject.Find("Player");
       // Weapon player = Player.GetComponent<Weapon>();
       // killCounter = player.kills;
        //botsKilledFromScript = player.kills;
    }

    // Update is called once per frame
    private void Update()
    {
        GameObject Player = GameObject.Find("Player");
        Weapon player = Player.GetComponent<Weapon>();
        botsKilledFromScript = player.kills;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (botsKilledFromScript == 10)
        {
            Debug.Log("LEVEL FINISHED");
            LoadLevels newLevel = GameObject.Find("End Trigger").GetComponent<LoadLevels>();
            readyToTransition = true;
        }
        //else
       // {
       //     Debug.Log("KILL THE REST");
        //}
    }
}
