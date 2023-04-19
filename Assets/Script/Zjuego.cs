using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Zjuego : MonoBehaviourPunCallbacks
{
    Player[] jugadores;
    public int jugador;
    void Start()
    {

    }

    void Update()
    {

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        jugadores = PhotonNetwork.PlayerList;
        jugador = jugadores.Length;
        Debug.Log("Se unió el jugador no." + jugador);
        PhotonNetwork.NickName = jugador.ToString();
    }
    public override void OnJoinedRoom()
    {
        jugadores = PhotonNetwork.PlayerList;
        jugador = jugadores.Length;
        Debug.Log("Se unió el jugador no." + jugador + "a la sala");
        PhotonNetwork.NickName = jugador.ToString();
    }
}
