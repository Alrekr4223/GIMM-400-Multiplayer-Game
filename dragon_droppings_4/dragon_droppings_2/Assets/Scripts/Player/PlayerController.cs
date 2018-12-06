using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float m_Health;

    public AudioClip m_PlayerGotHit;
    public AudioClip m_FireWeapon;
    

    private bool shootTimerComplete = true;

    private UIManager m_UIManager;
    

    private void Start()
    {
        //this sets the rotation point to zero
        transform.rotation = Quaternion.identity;

        m_Health = 100; // Default, Hard coded number will change

        m_UIManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        

        //Fire Weapon
        if(Input.GetMouseButtonDown(0) && shootTimerComplete)
        {
            if(m_UIManager.m_AmmoAmount > 0)
            {
                CmdFire();
                m_UIManager.ModifyAmmo(-1);
                gameObject.GetComponent<AudioSource>().clip = m_FireWeapon;
                gameObject.GetComponent<AudioSource>().Play(0);
            }
            else
            {
                m_UIManager.NoAmmo();
            }
            
            shootTimerComplete = false;
            StartCoroutine(Wait(1));
        }

        if(m_Health <= 0)
        {
            //Reset Player back to start location
            this.gameObject.transform.position = FindObjectOfType<NetworkStartPosition>().transform.position;
            m_UIManager.ResetVigette();
            m_Health = 100;
        }
    }

    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 60;

        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.blue;
    }


    public void RemoveHealth(float amount)
    {
        m_Health -= amount;
        m_UIManager.MoreVigette();
        Debug.Log("You've been hurt! Current Health: " + m_Health);
        gameObject.GetComponent<AudioSource>().clip = m_PlayerGotHit;
        gameObject.GetComponent<AudioSource>().Play(0);
    }



    IEnumerator Wait(float length)
    {
        yield return new WaitForSeconds(length);
        shootTimerComplete = true;
    }
}