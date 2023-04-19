using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Zjuego : MonoBehaviourPunCallbacks
{
    Photon.Realtime.Player[] jugadores;
    public int jugador;
    public GameObject jugadorGO;
    public PhotonView PV;

    void Start()
    {
        PV= GetComponent<PhotonView>();
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
        Debug.Log("Se unió el jugador no. " + jugador);
        PhotonNetwork.NickName = jugador.ToString();
        jugadorGO = PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0);
    }

}

