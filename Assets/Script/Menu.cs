using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

    public void Salir()
    {
        Debug.Log("salir...");
        Application.Quit();

    }
    public void CargarJuego()
    {
        SceneManager.LoadScene("JUEGO");
    }

}
