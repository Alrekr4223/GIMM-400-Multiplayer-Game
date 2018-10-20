using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    //INCOMPELTE 
    //Currently on '12.Player Health'
    //https://unity3d.com/learn/tutorials/topics/multiplayer-networking/player-health-single-player?playlist=29690



    public GameObject m_BulletPrefab;
    public Transform m_BulletSpawn;
	
	void Start () {

        if (!isLocalPlayer)
        {
            GetComponent<PlayerController>().enabled = false;
        }
		
	}


    //This function is only called by the LocalPlayer on their Client. This will make each player see their local player GameObject as blue. The OnStartLocalPlayer function is a good place to do initialization that is only for the local player, such as configuring cameras and input.
    public override void OnStartLocalPlayer()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }


    }

    //The[Command] attribute indicates that the following function will be called by the Client, but will be run on the Server. Any arguments in the function will automatically be passed to the Server with the Command. Commands can only be sent from the local player object. When making a networked command, the function name must begin with “Cmd”.

    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
             m_BulletPrefab,
            m_BulletSpawn.position,
            m_BulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = this.transform.forward * 6;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
