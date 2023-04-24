using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectMaster : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.GameVersion = "1.0.3";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a  conectar al servidor Master");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene  = true;
        Debug.Log("Se ha conectado al servidor Maestro");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Problemas al conectar al servidor");
    }
}
