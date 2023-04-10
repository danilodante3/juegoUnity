using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class ResultPanel : MonoBehaviour
{
    public int tiempoJuego;
    private int tiempoRestante;
    public GameObject resultPanel; // el panel que mostrará el resultado
    public Text resultText; // el componente de texto en el panel

    public GameObject targetLeft;
    public GameObject targetRight;

    private int leftGoals = 0;
    private int rightGoals = 0;

    public void UpdateGoals()
{
    

}

    public void ShowResult()
    {
        // determina el resultado del partido
        string result = "";
        if (leftGoals > rightGoals)
        {
            result = "¡Ganaste!";
        }
        else if (leftGoals < rightGoals)
        {
            result = "¡Perdiste!";
        }
        else
        {
            result = "¡Empate!";
        }

        // actualiza el texto del panel con el resultado y la cantidad de goles marcados en cada objetivo
        resultText.text = result + "\n\n" + "Goles:\nIzquierda " + leftGoals + " - Derecha " + rightGoals;

        // muestra el panel
        resultPanel.SetActive(true);
    }

    void Update()
    {
        // actualiza el tiempo restante
        tiempoRestante = (int)(tiempoJuego - Time.time);

        // verifica si se acabó el tiempo
        if (tiempoRestante <= 0)
        {
            // actualiza los goles y muestra el resultado
            UpdateGoals();
            ShowResult();
        }
    }
}