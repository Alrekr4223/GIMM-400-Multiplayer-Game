using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileAggro : HostileState {


    public HostileAggro(HostileController hostileController) : base(hostileController) { }

    public override void CheckTransition()
    {
        if (!hostileController.CheckIfInRange("Player"))
        {
            hostileController.SetState(new HostileStormCastle(hostileController));

        }
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hostileController.transform.position) < 3)
        {
            hostileController.SetState(new HostileKill(hostileController));
        }
    }
    public override void Act() //Running Every Frame
    {
        hostileController.m_Agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        
    }
    public override void OnStateEnter() //Only On trigger enter
    {
        Debug.Log("Aggro on Player");
        hostileController.ChangeColor(Color.red);
        hostileController.m_Agent.speed = 10;
        
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
