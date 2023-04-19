using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Cuartos1 : MonoBehaviourPunCallbacks
{
    public int numero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void CrearRoom()
    {
        numero = Random.Range(1, 100);
        Debug.Log("Se va a crear una nueva Room");
        PhotonNetwork.JoinOrCreateRoom("Sala no." + numero, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        Debug.Log("Se creoo una nueva Room" + numero);
        PhotonNetwork.LoadLevel("ONLINE");


    }
    public override void OnCreateRoomFailed(short returnCode, string Message)
    {
        
        Debug.Log("Nose pudo crear la sala, se volvera");
        CrearRoom();
    }
}
