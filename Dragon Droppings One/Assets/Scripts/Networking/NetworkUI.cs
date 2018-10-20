using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkUI : NetworkBehaviour {

    public Text ipText;
    public Text portText;

    public void StartHost()
    {
        NetworkManager.singleton.StartHost();
    }

    public void StartClient()
    {
        if(ipText.text.Length > 0 && ipText.text != null)
        {
            NetworkManager.singleton.networkAddress = ipText.text;
            int x;
            int.TryParse(portText.text, out x);
            NetworkManager.singleton.networkPort = x;

            NetworkManager.singleton.StartClient();
        }
        else
        {
            print("Please Enter IP");
        }
    }



}
