using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Multiplayer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();



    }

    void Update()
    {

    }
    public override void OnConnectedToMaster() 
      {
        PhotonNetwork.JoinLobby();
      }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("cuarto", new RoomOptions { MaxPlayers = 5 }, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("J", new Vector2(Random.Range(-6,6),3), Quaternion.identity);
    }
}
