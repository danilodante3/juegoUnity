using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class Unirse : MonoBehaviourPunCallbacks
{
    public int numero;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UnirseRoom()
    {
            PhotonNetwork.ConnectUsingSettings();

        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Se unio a una room aleatoria");
        }
        else
        {
            Debug.Log("Aun no se ha conectado al servidor, espera a OnConnectedToMaster o OnJoinedLobby");
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Nose pudo unir a ninguna, se creara una nueva sala");
        CrearRoom();
    }
    public void CrearRoom()
    {
        numero = Random.Range(1, 100);
        Debug.Log("Se va a crear una nueva sala");
        PhotonNetwork.JoinOrCreateRoom("Sala no." + numero, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        Debug.Log("Se creo una nueva room" + numero);
        PhotonNetwork.LoadLevel("ONLINE");

    }
    public override void OnCreateRoomFailed(short returnCode, string Message)
    {

        Debug.Log("Nose pudo crear la sala, se volvera");
        CrearRoom();
    }
}
