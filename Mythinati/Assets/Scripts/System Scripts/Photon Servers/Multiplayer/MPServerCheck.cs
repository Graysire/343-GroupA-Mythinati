using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPServerCheck : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); 
        // Connects to Photon Master Servers
        // For our group, should be US West
        // denoted as "usw"
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the " + PhotonNetwork.CloudRegion + " server.");
        // Message display on console window to check which cloud region it
        // connects to 
        // base.OnConnectedToMaster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
