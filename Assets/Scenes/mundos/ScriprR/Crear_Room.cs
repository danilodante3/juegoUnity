using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Crear_Room : MonoBehaviourPunCallbacks
{
    public int numero;
    void Start()
    {
        
    }

    public void CrearRoom()
    {
        numero = Random.Range(1,100);
        Debug.Log("Se va a crear una nueva room");
        PhotonNetwork.JoinOrCreateRoom("sala no." + numero, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        Debug.Log("Se creo una nueva room" + numero);
        PhotonNetwork.LoadLevel("ONLINE");
        PhotonNetwork.AutomaticallySyncScene = true;



    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo crear la sala, se volvera a intentar crear una");
        CrearRoom();
    }
}
