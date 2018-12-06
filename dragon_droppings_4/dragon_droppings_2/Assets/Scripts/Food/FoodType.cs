using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodType : MonoBehaviour {

    public float m_Damage;

    public string m_FoodColor;

    public GameObject m_PoopPrefab;

    private bool ammoTimerComplete = true;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().bulletPrefab.GetComponent<BulletType>().m_ProjectileDamage = m_Damage;
            FindObjectOfType<UIManager>().ChangeAmmoImage(m_FoodColor);
            m_PoopPrefab.gameObject.GetComponent<BulletType>().ChangeAmmoType(m_FoodColor);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && ammoTimerComplete)
        {
            ammoTimerComplete = false;
            FindObjectOfType<UIManager>().ModifyAmmo(1);

            Debug.Log("Giving Player more Ammo");

            StartCoroutine(Wait(0.5f));
        }
    }


    IEnumerator Wait(float length)
    {
        yield return new WaitForSeconds(length);
        ammoTimerComplete = true;
    }
}
