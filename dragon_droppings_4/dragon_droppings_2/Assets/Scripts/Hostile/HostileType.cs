using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileType : MonoBehaviour {

    public Transform m_TargetDestination;
    private NavMeshAgent m_Agent;


    // Use this for initialization
    void Start() {

        

        m_Agent = this.GetComponent<NavMeshAgent>();

        //Set the destination 
        m_Agent.destination = m_TargetDestination.position;

        m_Agent.speed = 5;



        
    }
}
