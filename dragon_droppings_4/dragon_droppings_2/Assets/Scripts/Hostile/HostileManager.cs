using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileManager : MonoBehaviour {


    //Hostile Spawning and Amount control.
    //Overall Manager


    public int m_MaxHostiles; 
    public int m_AmountOfHostiles;
    public GameObject m_HostilePrefab;
    public Transform m_SpawnLocation;

    private GameManager m_GM;



	// Use this for initialization
	void Start () {

        Debug.Log("Starting Hostile Manager");
        SpawnHostile(m_MaxHostiles);
        m_GM = FindObjectOfType<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
        //Used for constant spawnning of hostiles
        /*
        if(m_AmountOfHostiles <= m_MaxHostiles)
        {
            SpawnHostile(1);
        }*/

        //Used for static amount of hostiles.
        if(m_AmountOfHostiles <= 0)
        {
            m_GM.GameWin();
        }

	}



    void SpawnHostile(int numToSpawn)
    {
        int spawnCounterX = 0;
        int spawnCounterZ = 0;

        for (var i = 0; i < numToSpawn; i++)
        {
            m_AmountOfHostiles++;
            GameObject curHos = Instantiate<GameObject>(m_HostilePrefab);
            curHos.GetComponent<NavMeshAgent>().enabled = false;

            spawnCounterX++;
            if (spawnCounterX >= 5)
            {
                spawnCounterX = 0;
                spawnCounterZ++;
            }

            Vector3 transOffset = new Vector3(m_SpawnLocation.position.x - spawnCounterX * 2, m_SpawnLocation.position.y, m_SpawnLocation.position.z - spawnCounterZ * 2);
            curHos.transform.position = transOffset;
            curHos.transform.parent = this.gameObject.transform;

            Debug.Log("Hostile Manager Loop #" + i);

        }
    }

    public void LostHostile(int amount)
    {
        m_AmountOfHostiles = m_AmountOfHostiles - amount;
    }

}
