using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileKill : HostileState {

    public HostileKill(HostileController hostileController) : base(hostileController) { }

    private GameObject m_Player;

    public override void CheckTransition()
    {

        if (Vector3.Distance(m_Player.transform.position, hostileController.transform.position) > 5)
        {
            hostileController.SetState(new HostileAggro(hostileController));
        }

    }
    public override void Act() //Running Every Frame
    {
        
        hostileController.m_Agent.destination = new Vector3(hostileController.transform.position.x, hostileController.transform.position.y, hostileController.transform.position.z);

        Vector3 targetDir = m_Player.transform.position - hostileController.transform.position;
        hostileController.transform.rotation = Quaternion.LookRotation(targetDir);

        //Face Player at all times.
    }
    public override void OnStateEnter() //Only On trigger enter
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log("Attacking Player!!!");
        hostileController.m_Agent.speed = 3;

        float rand = Mathf.Round(Random.Range(0, 2));
        int notRand = int.Parse(rand.ToString());
        Debug.Log("Rand: " + rand);

        switch (notRand) {
            case 0:
                Debug.Log("Case 1, Hostile Kill");
                hostileController.gameObject.GetComponent<Animator>().Play("HostileAttack1");
                break;
            case 1:
                Debug.Log("Case 2, Hostile Kill");
                hostileController.gameObject.GetComponent<Animator>().Play("HostileAttack3");
                break;
        }

        Debug.Log("Past Switch");

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
