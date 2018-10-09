﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileKill : HostileState {


    



    public HostileKill(HostileController hostileController) : base(hostileController) { }

    public override void CheckTransition()
    {

        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hostileController.transform.position) > 3)
        {
            hostileController.SetState(new HostileAggro(hostileController));
        }

    }
    public override void Act() //Running Every Frame
    {
        hostileController.m_Agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    public override void OnStateEnter() //Only On trigger enter
    {
        Debug.Log("Attacking Player!!!");
        hostileController.ChangeColor(Color.yellow);
        hostileController.m_Agent.speed = 2;

    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}