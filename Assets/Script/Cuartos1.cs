using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class Cuartos1 : MonoBehaviourPunCallbacks
{
    public int numero;

    void Start()
    {
        // Conexión al servidor de Photon
        PhotonNetwork.ConnectUsingSettings();
    }
    public void CrearRoom()
    {
        numero = Random.Range(1, 100);
        Debug.Log("Se va a crear una nueva Room");
        PhotonNetwork.JoinOrCreateRoom("Sala no." + numero, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al servidor de Photon");
        CrearRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo crear la sala, se intentará de nuevo.");
        CrearRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Unido a la sala: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("ONLINE");
    }
}
