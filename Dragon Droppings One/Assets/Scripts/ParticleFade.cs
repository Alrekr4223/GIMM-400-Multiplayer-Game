using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFade : MonoBehaviour {

    private GameObject m_Player;

    private float m_DefaultDistance = 40;
    private float m_CurrentDistance;

	// Use this for initialization
	void Start () {

        m_Player = GameObject.FindGameObjectWithTag("Player");

        m_CurrentDistance = m_DefaultDistance;

	}
	
	// Update is called once per frame
	void Update () {

        m_CurrentDistance = Vector3.Distance(gameObject.transform.position, m_Player.transform.position);

        if (m_CurrentDistance < m_DefaultDistance)
        {
            //Decrease width of trail based on distance to player
            float percent = (m_CurrentDistance / m_DefaultDistance) - 0.10f;
            float defaultTrailWidth = 0.45f;        //Width of trail is max .45f, Ratio is 0-0.45f to 0-40.0f
            Debug.Log("Percent: " + percent + "%, ParticleFade Update()");


            ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();
            var trail = ps.trails;
            trail.widthOverTrail = defaultTrailWidth * percent;
        }

	}
}
