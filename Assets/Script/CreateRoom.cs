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
    public override void OnCreatedRoom()
    {

        MasterManager.DebugConsole.AddText("created room successfully.", this);
    }
    public override void OnCreatedRoomFailed(short returnCod, string message)
    {

        MasterManager.DebugConsole.AddText("Room creation failed:" + message, this);
    }
}
