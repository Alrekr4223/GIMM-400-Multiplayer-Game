using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject m_AmmoAmountText;
    public GameObject m_AmmoImage;

    public float m_AmmoAmount;


    private bool foundPlayer = false;

    private PostProcessingProfile m_Prof;

    // Use this for initialization
    void Start () {

        m_AmmoAmount = 10;
        m_AmmoAmountText.GetComponent<Text>().text = m_AmmoAmount.ToString();

    }

	
	// Update is called once per frame
	void Update () {

        if (!foundPlayer)
        {
            try{
                m_Prof = Camera.main.gameObject.GetComponent<PostProcessingBehaviour>().profile;
            }
            catch
            {
                //No player in the scene/No Processing found
                return;
            }
            
            foundPlayer = true;
            ResetVigette();
        }
	}

    public void NoAmmo()
    {
        m_AmmoAmountText.GetComponent<Text>().text = "No Ammo!";
    }

    public void ModifyAmmo(float amount)
    {
        m_AmmoAmount += amount;

        m_AmmoAmountText.GetComponent<Text>().text = m_AmmoAmount.ToString();
    }

    public void ResetVigette()
    {
        VignetteModel.Settings vig = m_Prof.vignette.settings;
        vig.intensity = 0;
        m_Prof.vignette.settings = vig;
    }

    public void MoreVigette()
    {        
        VignetteModel.Settings vig = m_Prof.vignette.settings;
        vig.intensity += 0.0002f; //Hard Coded number. 0.0005 is too much, 0.00005 is too little. I think this itterates per frame.
        Debug.Log("Current Vig: " + vig.intensity);
        m_Prof.vignette.settings = vig;
    }

    public void ChangeAmmoImage(string type)
    {
        switch(type)
        {
            case "red":
                m_AmmoImage.GetComponent<Image>().color = Color.red;
                break;
            case "blue":
                m_AmmoImage.GetComponent<Image>().color = Color.blue;
                break;
            case "green":
                m_AmmoImage.GetComponent<Image>().color = Color.green;
                break;
            case "yellow":
                m_AmmoImage.GetComponent<Image>().color = Color.yellow;
                break;
        }
    }
}
