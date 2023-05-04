using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Video;

public class CountdownTimer : MonoBehaviourPunCallbacks
{
    public float timer = 10f; 
    public Text countdownText;
    public VideoPlayer videoPlayer; // Agrega referencia al componente VideoPlayer
    private bool isVideoPaused = false;

    void Start()
    {
        PhotonNetwork.GameVersion = "1.0.3";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a conectar al servidor Master");
        videoPlayer.Prepare();
        videoPlayer.Play();
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
        if (timer <= 5f && !isVideoPaused) // Verifica si el tiempo ha llegado a 5 y el video no está pausado
        {
            videoPlayer.Pause(); // Pausa el video
            isVideoPaused = true; // Cambia el valor de la variable booleana a verdadero
        }
        if (Input.GetMouseButtonDown(0) && isVideoPaused) // Verifica si el usuario ha tocado la pantalla y el video está pausado
        {
            videoPlayer.Play(); // Reanuda el video
            isVideoPaused = false; // Cambia el valor de la variable booleana a falso
        }
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