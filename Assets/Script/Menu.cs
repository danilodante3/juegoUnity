using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject fadeEffect;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fadeEffect.SetActive(true);
        }
    }
    public void Salir()
    {
        Debug.Log("salir...");
        Application.Quit();

    }
    public void CargarJuego()
    {
        SceneManager.LoadScene("Selector");
    }


}
