using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Photon.Realtime;
using UnityEngine.UI;

public class VideoC : MonoBehaviourPunCallbacks
{
    public VideoPlayer videoPlayer;
    public Text pressToContinueText;

    private bool isPaused = false;

    void Start()
    {
        videoPlayer.Play();
        StartCoroutine(PauseVideo());
        StartCoroutine(ShowPressToContinueText());
        videoPlayer.loopPointReached += OnVideoFinished;
        PhotonNetwork.GameVersion = "1.0.3";
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Se va a conectar al servidor Master");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPaused)
        {
            videoPlayer.Play();
            isPaused = false;
            pressToContinueText.gameObject.SetActive(false);
        }

        if (!isPaused)
        {
            pressToContinueText.gameObject.SetActive(false);
        }
    }

    IEnumerator PauseVideo()
    {
        yield return new WaitForSeconds(2f);
        videoPlayer.Pause();
        isPaused = true;
    }

    IEnumerator ShowPressToContinueText()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            pressToContinueText.gameObject.SetActive(isPaused && !pressToContinueText.gameObject.activeSelf);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("MENU");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Se ha conectado al servidor Maestro");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Problemas al conectar al servidor...");
    }
}
