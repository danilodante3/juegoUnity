using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class VideoController : MonoBehaviourPunCallbacks
{
    public VideoPlayer videoPlayer;



    void Start()
    {
        videoPlayer.Play();
        videoPlayer = GetComponent<VideoPlayer>();

        PhotonNetwork.GameVersion = "1.0.3";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a conectar al servidor Master");
    }

    void Update()
    {
        if (videoPlayer.time >= 5.0f && !videoPlayer.isPaused)
        {
            videoPlayer.Pause();
        }
        if (Input.GetMouseButtonDown(0) && videoPlayer.isPaused)
        {
            videoPlayer.Play();
        }
        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("MENU");
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
