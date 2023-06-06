using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void CargarJuego()
    {


        SceneManager.LoadScene("Selector");
    }
    // Update is called once per frame
    public void Online () {

        SceneManager.LoadScene("LISTA");
    
    }
    void Update()
    {

    }
}