using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnirseRoom : MonoBehaviourPunCallbacks
{
    public int numero;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void unirseRooms()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Se unio a una room aleatoria");
        }
        else
        {
            Debug.LogError("Not connected to server.");
        }
    }
    

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo unir a ninguna, se creara una nueva sala");
        Crearroom();
    }

    public void Crearroom()
    {
        numero = Random.Range(1, 100);
        Debug.Log("Se va a crear una nueva room");
        PhotonNetwork.CreateRoom("sala no." + numero, new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo crear la sala, se volvera a intentar crear una");
        Crearroom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("ONLINE");
            PhotonNetwork.AutomaticallySyncScene = true;

    }
}

