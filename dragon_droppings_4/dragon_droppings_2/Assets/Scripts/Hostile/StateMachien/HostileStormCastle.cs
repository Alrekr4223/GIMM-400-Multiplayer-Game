using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileStormCastle : HostileState {

    Transform m_Destination;

    public HostileStormCastle(HostileController hostileController) : base(hostileController) {  }
    

    public override void CheckTransition()
    {
        if (hostileController.CheckIfInRange("Player"))
        {
            hostileController.SetState(new HostileAggro(hostileController));
        }
    }
    public override void Act()
    {
        /*
        try
        {
            //hostileController.GetComponent<Animator>().Play("Armature|Run");
            AnimatorClipInfo[] clipInfo = hostileController.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
            Debug.Log("Clip Name: " + clipInfo[0].clip.name);

            //https://docs.unity3d.com/Manual/AnimatorOverrideController.html

            hostileController.GetComponent<Animator>().Play("Armature|Run", 0);
        }
        catch
        {
            Debug.Log("Couldn't Find animation");
        }
        */
    }
    public override void OnStateEnter()
    {
        Debug.Log("Storming Castle");
        //hostileController.ChangeColor(Color.blue);
        hostileController.m_Agent.speed = 15f;
        hostileController.m_Agent.destination = hostileController.m_TargetDestination.position;
        hostileController.gameObject.GetComponent<Animator>().Play("HostileRun");


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
