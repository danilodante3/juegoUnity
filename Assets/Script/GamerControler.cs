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
    public GameObject WinL;
    public Image flagLeft, flagRigh;
    public Text nameLeft, nameRigh;
    public AudioClip losingMusic,losingAi;


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
        number_GoalsLeft  = 0;
        tiempoJuego = 290;
        _ball = GameObject.FindGameObjectWithTag("ball");
        _Ai = GameObject.FindGameObjectWithTag("Ai");
        _Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InicioJuego());
        PhotonNetwork.AutomaticallySyncScene = true;


    }
    public void Musica()
    {
        if (Input.GetKeyDown(KeyCode.Space))
       
            {
            AudioListener.pause = !AudioListener.pause;
        }
        if(Input.GetKeyDown(KeyCode.Space))


            {
            AudioListener.pause = !AudioListener.pause;
        }
    }
    void Update()
    {
        txt_GoolsRight.text = number_GoalsRight.ToString();
        txt_GoolsLeft.text = number_GoalsLeft.ToString();
        txt_tiempoJuego.text = tiempoJuego.ToString();

        if (number_GoalsRight < number_GoalsLeft && tiempoJuego > 05)

        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().clip = losingMusic;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (number_GoalsLeft < number_GoalsRight && tiempoJuego > 05)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().clip = losingAi;
                GetComponent<AudioSource>().Play();
            }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void cerrar()
    {
        Application.Quit();
    }
    public void Cargar1(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

    }

    public void MostrarPanel(string nombreEquipo, int golesEquipo)
    {
        WinL.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;

        Text txtResultado = WinL.GetComponentInChildren<Text>();
        txtResultado.text = nombreEquipo + " ganó " + golesEquipo + " a " + number_GoalsLeft;

        Image escudoEquipo = WinL.transform.Find("Image").GetComponent<Image>();
        if (golesEquipo > number_GoalsLeft)
        {
            escudoEquipo.sprite = flagRigh.sprite; // Mostrar la imagen de la bandera del equipo derecho
        }
        else if (golesEquipo < number_GoalsLeft)
        {
            escudoEquipo.sprite = flagLeft.sprite; // Mostrar la imagen de la bandera del equipo izquierdo
        }
        else
        {
            escudoEquipo.sprite = null; // Mostrar una imagen por defecto si hay empate
        }
    }


}

