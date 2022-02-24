using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{

    //Initiating necessary states and variables
    public Animator transition;
    public Animator victory;
    EndTrigger levelStatus;
    private bool changeLevel;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)      //First Level
        {
           levelStatus = GameObject.Find("End Trigger").GetComponent<EndTrigger>(); //Different End Trigger naming for levels 1 and 2
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)      //Second Level
        {
            levelStatus = GameObject.Find("End Trigger 2").GetComponent<EndTrigger>();      //Naming for End Trigger Level 2
        } 
        changeLevel = levelStatus.readyToTransition;            //Ready to transition variable from other file.
        if (changeLevel == true)
        {
            loadNextLevel();                //Adding 1 to level index to load next scene
            //Debug.Log("ChangeLevel is true");

         if (SceneManager.GetActiveScene().buildIndex == 1)     //Ensuring final level for victory trigger
         {
                Debug.Log("VICTORY TRIGGERED");
                loadVictoryScreen();
         }

        }
    }

    void loadVictoryScreen()
    {
        victory.SetTrigger("Won");      //Simple Trigger to initiate victory screen
    }

    void loadNextLevel()
    {
        StartCoroutine(delaySceneTransition(SceneManager.GetActiveScene().buildIndex + 1));     //Delay scene transition to allow animation to take place
        
    }

    private IEnumerator delaySceneTransition(int index)
    {

        Debug.Log("Level Transfer Triggered");
        transition.SetTrigger("Start");             //Trigger and delay while animation plays

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(index);              //Load next level
    }



}
