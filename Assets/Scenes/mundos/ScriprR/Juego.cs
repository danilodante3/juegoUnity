using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Juego : MonoBehaviourPunCallbacks
{
    Photon.Realtime.Player[] jugadores;

    public int jugador;
    public GameObject jugadorGO;
    public PhotonView PV;
    

    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {

    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        jugadores = PhotonNetwork.PlayerList;
        jugador = jugadores.Length;
        Debug.Log("Se unió el jugador no. " + jugador);
        PhotonNetwork.NickName = jugador.ToString();

    }

    public override void OnJoinedRoom()
    {

        jugadores = PhotonNetwork.PlayerList;
        jugador = jugadores.Length;
        Debug.Log("Se unio al jugador no." + jugador + "a la sala");
        PhotonNetwork.NickName= jugador.ToString();

        jugadorGO = PhotonNetwork.Instantiate("Player2", new Vector3(3.98f, -1.04694f, 0f), Quaternion.Euler(0f, 180f, 0f), 0);

        PhotonNetwork.AutomaticallySyncScene = true;

          
    }


}
