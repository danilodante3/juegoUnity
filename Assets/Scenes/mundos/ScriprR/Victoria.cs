using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class NewBehaviourScript : MonoBehaviour
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
    public AudioClip losingMusic, losingAi;
    public void MostrarPanel(string nombreEquipo, int golesEquipo)
    {
       
        WinM.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;

        Text txtResultado = WinM.GetComponentInChildren<Text>();
        txtResultado.text = nombreEquipo + " ganó " + golesEquipo + " a " + number_GoalsLeft;

        Image escudoEquipo = WinM.transform.Find("Image").GetComponent<Image>();
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
