using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class COnexion1 : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a conectar al servidor Master");

    }

    // Update is called once per frame
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Se ha conectado al servidor Maestro");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Problema al conectar al serivdor");
    }

}
