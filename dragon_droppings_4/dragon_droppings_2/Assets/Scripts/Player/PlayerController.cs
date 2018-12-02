using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float m_Health;
    

    private void Start()
    {
        //this sets the rotation point to zero
        transform.rotation = Quaternion.identity;

        m_Health = 100; // Default, Hard coded number will change
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * 3f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            CmdFire();
        }

        if(m_Health <= 0)
        {
            //Reset Player back to start location
            this.gameObject.transform.position = FindObjectOfType<NetworkStartPosition>().transform.position;
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
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 60;

        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }


    public void RemoveHealth(float amount)
    {
        m_Health -= amount;
        Debug.Log("You've been hurt! Current Health: " + m_Health);
    }
}