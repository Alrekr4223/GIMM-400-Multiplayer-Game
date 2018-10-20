using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileController : MonoBehaviour {

    public HostileState currentState;
    public Transform m_TargetDestination;
    public NavMeshAgent m_Agent;

    public GameObject[] hostiles;
    private float detectionRange = 20;
    public GameObject hostileToChase;




    // Use this for initialization
    void Start () {

        m_Agent = this.GetComponent<NavMeshAgent>();
        SetState(new HostileStormCastle(this));


    }


	
	// Update is called once per frame
	void Update () {

        currentState.CheckTransition();
        currentState.Act();
		
	}




    public bool CheckIfInRange ( string tag)
    {
        hostiles = GameObject.FindGameObjectsWithTag(tag);
        if(hostiles != null)
        {
            foreach (GameObject h in hostiles)
            {
                if(Vector3.Distance(h.transform.position, this.transform.position) < detectionRange)
                {
                    hostileToChase = h;
                    return true;
                }
            }
        }
        return false;
    }



    public void ChangeColor(Color f_color)
    {
        try
        {
            this.gameObject.GetComponent<Renderer>().material.color = f_color;
        }
        catch
        {
            try
            {
                this.GetComponentInChildren<Renderer>().material.color = f_color;
            }
            catch
            {
                Debug.Log("I can't find a Renderer");
            }
        }
        
    }



    public void SetState(HostileState f_state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = f_state;
        //this.gameObject.name = "This Object is in the state: " + f_state.GetType().Name;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
}
