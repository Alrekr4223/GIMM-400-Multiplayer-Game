using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour {

    public Button m_playButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_playButton.onClick.AddListener(StartNetworkLobby);
	}

    void StartNetworkLobby ()
    {
        SceneManager.LoadScene("NetworkLobby");
    }
}
