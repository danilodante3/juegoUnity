using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoom : MonoBehaviour
{
    [SerializeField]
    private Text _roomName;
  

    public void Onclick_CreateRoom() 
    
    {
        if (!PhotonNetwork.IsConnected)
            return;
        RoomOptions options= new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("basic", options, TypedLobby.Default);
    }
}
