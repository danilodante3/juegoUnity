using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CountdownTimer : MonoBehaviourPunCallbacks
{
    public float timer = 10f; 
    public Text countdownText; 

    void Start()
    {
        PhotonNetwork.GameVersion = "1.0.3";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a conectar al servidor Master");

        countdownText.text = timer.ToString("0"); 
    }

    void Update()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0f) 
        {
            PhotonNetwork.LoadLevel("MENU"); 
        }

        countdownText.text = timer.ToString("0"); 
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Se ha conectado al servidor Maestro");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Problemas al conectar al servidor");
    }
}