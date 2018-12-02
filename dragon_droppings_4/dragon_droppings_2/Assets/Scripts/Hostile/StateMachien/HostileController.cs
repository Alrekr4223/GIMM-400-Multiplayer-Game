using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileController : MonoBehaviour {

    //Base of State Machine
    //Individual to each hostile
    //Contains base information on Hostile

    public float m_CurrentHealth;

    public NavMeshAgent m_Agent;
    public Transform m_TargetDestination;

    public GameObject[] hostiles;
    public GameObject hostileToChase;

    public GameManager m_GM;
    public HostileManager m_HostileManager;
    public HostileState currentState;


    private float detectionRange = 20;
    private float m_MaxHealth = 100;


    // Use this for initialization
    void Start () {

        //Navigation and State Machine
        this.GetComponent<NavMeshAgent>().enabled = true; //Needs to be switched on and off when spawning through network manager.
        m_Agent = this.GetComponent<NavMeshAgent>();
        m_TargetDestination = FindObjectOfType<HostileDesination>().transform;
        SetState(new HostileStormCastle(this));


        //Health Management
        m_CurrentHealth = m_MaxHealth;

        //Used for ending game
        m_GM = FindObjectOfType<GameManager>();

        //Used for sending data to manager
        m_HostileManager = FindObjectOfType<HostileManager>();

    }
	
	// Update is called once per frame
	void Update () {

        //State Machine Core
        currentState.CheckTransition();
        currentState.Act();

        //Constant check on this hostile's health
        if(m_CurrentHealth <= 0)
        {
            HostileDead();
        }

        //How far away the hostile is  from the town.
        float distance = Vector3.Distance(this.gameObject.transform.position, m_TargetDestination.transform.position);

        //You Lose if the hostile gets too close to the town
        if(distance <= 50)
        {
            m_GM.GameLose();
            HostileDead();
        }
		
	}
    

    //Checking if hostile's distance from Player is within parameter range. Range is var detectionRange
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

    //Editing material color for testing
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

    //State Machine Core
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

    //Hostile has been damaged by specific amount. 
    public void HostileDamaged(float amount)
    {
        m_CurrentHealth = m_CurrentHealth - amount;
    }

    //Hostile is removed from game.
    private void HostileDead()
    {
        m_HostileManager.LostHostile(1); //Data sent to Manager for assement. 1 hostile has died.
        Destroy(this.gameObject);   //Complete removal of this object
    }
}
