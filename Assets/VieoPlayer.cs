using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class VieoController : MonoBehaviourPunCallbacks
{
    public VideoPlayer videoPlayer;
    private bool videoPaused = false;

    void Start()
    {
        videoPlayer.Play();
        PhotonNetwork.GameVersion = "1.0.3";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a conectar al servidor Master");
    }

    void Update()
    {
        if (!videoPaused && videoPlayer.time >= 5.0f)
        {
            videoPlayer.Pause();
            videoPaused = true;
        }

        if (videoPaused && Input.GetMouseButtonDown(0))
        {
            videoPlayer.Play();
            videoPaused = false;
        }

        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("NombreDeTuEscena");
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
