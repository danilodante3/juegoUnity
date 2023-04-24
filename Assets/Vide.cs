using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Vide : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("MENU");
    }
}