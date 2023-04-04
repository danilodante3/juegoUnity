using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Image flagLeft, flagRight;
    public Text nameLeft, nameRight;
    public Text result, goals;
    public static GamerControler instance;

    void Start()
    {
        goals.text = instance.number_GoalsLeft + " " + instance.number_GoalsRight;

        if (instance.number_GoalsLeft > instance.number_GoalsRight)
        {
            result.text = "You Lose";
        }
        else if (instance.number_GoalsLeft == instance.number_GoalsRight)
        {
            result.text = "Draw";
        }
        else
        {
           result.text = "You Win";
        }
    }
    public void ButtonHome()
    {
       ;
        SceneManager.LoadScene("Menu");

    }
    public void ButtonMatch ()
    {
        SceneManager.LoadScene("JUEGO");
    }
    public void ButtonExihition()
    {
        SceneManager.LoadScene("MENU");

    }
    
}

