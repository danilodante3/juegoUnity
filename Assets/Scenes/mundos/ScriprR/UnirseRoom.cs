using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class UnirseRoom : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject player2Prefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void unirseRooms()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Se unió a una sala aleatoria");
        }
        else
        {
            Debug.LogError("Not connected to server.");
        }
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo unir a ninguna sala, se creará una nueva sala");
        CrearRoom();
    }

    public void CrearRoom()
    {
        int numero = Random.Range(1, 100);
        Debug.Log("Se va a crear una nueva sala");
        PhotonNetwork.CreateRoom("sala no." + numero, new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("No se pudo crear la sala, se intentará crear una nueva");
        CrearRoom();
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(player2Prefab.name, Vector3.zero, Quaternion.identity);
        }

        PhotonNetwork.LoadLevel("ONLINEV1");
        PhotonNetwork.AutomaticallySyncScene = true;
    }
}

