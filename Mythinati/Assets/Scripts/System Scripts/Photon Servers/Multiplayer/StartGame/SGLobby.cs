using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGLobby: MonoBehaviourPunCallbacks 
{
    [SerializeField]
    private GameObject startGameButton;
    [SerializeField]
    private GameObject gameCancelButton;
    [SerializeField]
    private int sessionSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        startGameButton.SetActive(true);
        // base.OnConnectedToMaster();
    }

    public void StartGame()
    {
        startGameButton.SetActive(false);
        gameCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); // Joins an existing session
        Debug.Log("Multiplayer - Start Game");
    }

    void CreateRoom() // For creating a random session automatically
    {
        Debug.Log("Creating a random session right now...");
        int randRoomNum = Random.Range(0, 1000);
        RoomOptions roomOpts = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)sessionSize };
        PhotonNetwork.CreateRoom("Room" + randRoomNum, roomOpts);
        Debug.Log(randRoomNum);
    }

    public override void OnCreateRoomFailed(short failFlag, string message)
    {
        Debug.Log("Sorry, an open session does not exist at this time.");
        CreateRoom();
    }
    
    public void GameCancel()
    {
        startGameButton.SetActive(false);
        gameCancelButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
    
    
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
