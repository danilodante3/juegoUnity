using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GamerControler : MonoBehaviour
{
    public static GamerControler instance;
    public Text txt_GoolsRight, txt_GoolsLeft, txt_tiempoJuego;
    public int number_GoalsRight, number_GoalsLeft;
    public bool isScore, EndMatch;
    public float tiempoJuego;
    private GameObject _ball, _Ai, _Player;
    public GameObject WinL, WinM;
    public Image flagLeft, flagRigh;
    public Text nameLeft, nameRigh;
    public Text nameLeftResult, nameRightResult;
    public Text txt_GoolsRigh, txt_GoolsLef;
    public int number_GoalsRigh, number_GoalsLef;
    private bool isPaused = false;
        public GameObject winMPanel;
   public AudioClip winSound,lolsad;

    public AudioClip losingMusic, losingAi;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        number_GoalsRight = 0;
        number_GoalsLeft = 0;
        tiempoJuego = 280;
        _ball = GameObject.FindGameObjectWithTag("ball");
        _Ai = GameObject.FindGameObjectWithTag("Ai");
        _Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InicioJuego());
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {
        txt_GoolsRight.text = number_GoalsRight.ToString();
        txt_GoolsLeft.text = number_GoalsLeft.ToString();
        txt_tiempoJuego.text = tiempoJuego.ToString();
        txt_GoolsRigh.text = number_GoalsRight.ToString();
        txt_GoolsLef.text = number_GoalsLeft.ToString();

        if (number_GoalsRight < number_GoalsLeft && tiempoJuego > 5)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().clip = losingMusic;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (number_GoalsLeft < number_GoalsRight && tiempoJuego > 5)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().clip = losingAi;
                GetComponent<AudioSource>().Play();
            }
        }

        if (tiempoJuego <= 0)
        {
            EndMatch = true;
            ShowResultPanel();

        }
    }

    IEnumerator InicioJuego()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (tiempoJuego > 0)
            {
                tiempoJuego--;
            }
            else
            {
                EndMatch = true;
                break;
            }
        }
    }

    public void ContinueMatch(bool winPlayer)
    {
        StartCoroutine(WaitContinueMatch(winPlayer));
    }

    IEnumerator WaitContinueMatch(bool winPlayer)
    {
        yield return new WaitForSeconds(2f);
        isScore = false;
        if (EndMatch == false)
        {
            _ball.transform.position = new Vector3(0, 0, 0);
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _Ai.transform.position = new Vector3(-5, 0, 0);
            _Player.transform.position = new Vector3(6, 0, 0);
            if (winPlayer)
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
            }
            else
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
            }

        }
    }

    public void ButtonPause()
    {
        WinL.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    public void botonresumen()
    {
        WinL.SetActive(false); 
        Time.timeScale = 1;
        AudioListener.pause = false;
    }


    public void perder()
    {
        number_GoalsLeft= 3;
        number_GoalsRight= 0;
        tiempoJuego = 0;
        WinL.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;

        // Restablecer variables y componentes
        number_GoalsRight = 0;
        number_GoalsLeft = 0;
        tiempoJuego = 280;
        isScore = false;
        EndMatch = false;

        // Restablecer posiciones de objetos
        _ball.transform.position = new Vector3(0, 0, 0);
        _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _Ai.transform.position = new Vector3(-5, 0, 0);
        _Player.transform.position = new Vector3(6, 0, 0);

        // Reiniciar el juego
        StartCoroutine(InicioJuego());

        // Ocultar el panel WinM si está activo
        if (WinM.activeSelf)
        {
            WinM.SetActive(false);
        }
    }

    public void cerrar()
    {
        Application.Quit();
    }
    public void Cargar1(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

    }
    public void ShowResultPanel()
    {
        WinM.SetActive(true);
        if (number_GoalsLeft > number_GoalsRight)
        {
            flagLeft.enabled = true;
            flagRigh.enabled = false;
            nameLeftResult.text = "Winner";
            nameRightResult.text = "Loser";
            
        }
        else if (number_GoalsRight > number_GoalsLeft)

        {
            flagLeft.enabled = false;
            flagRigh.enabled = true;
            nameLeftResult.text = "Loser";
            nameRightResult.text = "Winner";
            
        }

        else 
        {
            flagLeft.enabled = false;
            flagRigh.enabled = false;
            nameLeft.text = "Left Team (Draw)";
            nameRigh.text = "Right Team (Draw)";
        }

        Time.timeScale = 0;
        AudioListener.pause = true;
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = winSound;
        audioSource.Play();
    }

    public void ReturnToMenu()
{
    Time.timeScale = 1f;

    // Restablecer las posiciones de los objetos relevantes
    _ball.transform.position = Vector3.zero;
    _Ai.transform.position = new Vector3(-5f, 0f, 0f);
    _Player.transform.position = new Vector3(6f, 0f, 0f);

    // Reiniciar otras configuraciones necesarias

    // Cargar la escena "MENU"
    SceneManager.LoadScene("MENU");
}


    public void jugar()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MENU");

    }
    public void musica()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pausar los audios
            AudioListener.pause = true;
        }
        else
        {
            // Reanudar los audios
            AudioListener.pause = false;
        }
    }

}

