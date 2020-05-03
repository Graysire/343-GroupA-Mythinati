using Photon.Pun;
using UnityEngine;

public class SGSession : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int newJoinedPlayers;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
        //base.OnEnable();
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
        //base.OnDisable();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a session.");
        StartGame();
        //base.OnJoinedRoom();
    }

    private void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Officially starting a random game.");
            PhotonNetwork.LoadLevel(newJoinedPlayers);
        }
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
