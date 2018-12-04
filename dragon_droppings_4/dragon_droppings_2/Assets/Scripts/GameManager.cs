using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GameLose()
    {
        Debug.Log("You've lost!!");
        //Transition to end screen.

        SceneManager.LoadScene("Loose");

    }

    public void GameWin()
    {
        Debug.Log("You've Won!");
        //Transition to end screen.

        SceneManager.LoadScene("Win");
    }
}
