﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet triggered something");
        
        if(other.gameObject.GetComponent<HostileController>() != null)
        {
            Debug.Log("Bullet found hostile: " + other.gameObject.name);
            GameObject hostile = other.gameObject;
            hostile.GetComponent<HostileController>().HostileDamaged(100);
            Destroy(this.gameObject);

        }
    }
}