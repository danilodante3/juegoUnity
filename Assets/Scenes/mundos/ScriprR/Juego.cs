using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviourPunCallbacks
{
    Photon.Realtime.Player[] jugadores;

    public int jugador;
    public GameObject jugadorGO;
    public PhotonView PV;
    public GameObject player2Prefab;
    public GameObject player2GO;


    public GameObject[] jugadoresGO;

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
        Debug.Log("Se unió al jugador no." + jugador + " a la sala");
        PhotonNetwork.NickName = jugador.ToString();

        if (jugador == 1)
        {
            jugadorGO = PhotonNetwork.Instantiate("Player", new Vector3(3.98f, -1.04694f, 0f), Quaternion.Euler(0f, 0f, 0f), 0);
            jugadorGO.name = "Player";
        }
        else if (jugador == 2)
        {
            jugadorGO = PhotonNetwork.Instantiate("Player2", new Vector3(-5f, 0, 0f), Quaternion.Euler(0f, 180f, 0f), 0);
            jugadorGO.name = "Player";

        }

        jugadoresGO = new GameObject[] { jugadorGO };

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void ReturnToMenu()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MENU");
    }



    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (otherPlayer.IsLocal)
        {
            Debug.Log("El jugador local abandonó la sala");
            PhotonNetwork.LoadLevel("MENU");
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            Debug.Log("El otro jugador abandonó la sala");
            
        }
    }


}