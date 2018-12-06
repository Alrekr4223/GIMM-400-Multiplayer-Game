using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour {


    public float m_ProjectileDamage;

    public AudioClip[] m_allAudioClips;
    public ParticleSystem[] m_allParticleSystems;


    public string m_AmmoType;

    public AudioClip m_CurrentAudioClip;
    public ParticleSystem m_CurrentParticleSystem;


	// Use this for initialization
	void Start () {

        //m_ProjectileDamage = 50; //Default Start
        //ChangeAmmoType("yellow");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAmmoType(string type)
    {
        Debug.Log("Changing Ammo Type to: " + type);

        switch (type)
        {
            case "yellow":
                //Debug.Log("Changing Ammo, Yellow");
                m_CurrentAudioClip = m_allAudioClips[0];
                m_CurrentParticleSystem = m_allParticleSystems[0];
                break;
            case "red":
                //Debug.Log("Changing Ammo, Red");
                m_CurrentAudioClip = m_allAudioClips[1];
                m_CurrentParticleSystem = m_allParticleSystems[0];
                break;
            case "blue":
                //Debug.Log("Changing Ammo, Blue");
                m_CurrentAudioClip = m_allAudioClips[3];
                m_CurrentParticleSystem = m_allParticleSystems[3];
                break;
            case "green":
                //Debug.Log("Changing Ammo, Green");
                m_CurrentAudioClip = m_allAudioClips[2];
                m_CurrentParticleSystem = m_allParticleSystems[2];
                break;
        }

        //Debug.Log("Changed Audio clip to: " + m_CurrentAudioClip.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.GetComponent<HostileController>() != null)
        {
            //Debug.Log("Bullet found hostile: " + other.gameObject.name);
            GameObject hostile = other.gameObject;
            hostile.GetComponent<HostileController>().HostileDamaged(m_ProjectileDamage);

            //Debug.Log("Current Audio Clip: " + m_CurrentAudioClip.name);

            gameObject.GetComponent<AudioSource>().clip = m_CurrentAudioClip;
            gameObject.GetComponent<AudioSource>().Play(0);

            //Hide Poop, Start poop splat particles, kill whole object after 1 second.
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            //this.gameObject.transform.Find("PoopSplat").GetComponent<ParticleSystem>().Play(); //OLD

            //m_CurrentParticleSystem.Play();//Doesnt work
            Destroy(this.gameObject, 1);

        }
    }
}
