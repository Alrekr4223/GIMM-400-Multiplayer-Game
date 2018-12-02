using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if(!isLocalPlayer)
        {
            GetComponent< PlayerController >().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponentInChildren<Camera>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
