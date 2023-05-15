using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject fadeEffect;
    private bool activateEffect = false;
    public GameObject btnarriba;

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
        btnarriba.transform.localScale = new Vector3(1, 1f, 1);
        btnarriba.GetComponent<Image>().CrossFadeAlpha(2f, 0.2f, true);

        activateEffect = true;
        SceneManager.LoadScene("Selector");
    }
    public void stopjuego()
    {
        btnarriba.transform.localScale = new Vector3(0.202831f, 0.1830744f, 1);
        btnarriba.GetComponent<Image>().CrossFadeAlpha(2f, 0.2f, true);
    }

}
