using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SceneChanger : MonoBehaviour {

    public Button m_playButton;

    public AudioClip m_Audio;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<AudioSource>().clip = m_Audio;
        gameObject.GetComponent<AudioSource>().Play(0);

    }
	
	// Update is called once per frame
	void Update () {
        m_playButton.onClick.AddListener(StartNetworkLobby);
	}

    public void StartNetworkLobby ()
    {
        //SceneManager.LoadScene("NetworkLobby");

        NetworkManager.Shutdown(); //Somehow there are two network managers when you run this, you have to stop the request and restart it through the HUD
    }
}
