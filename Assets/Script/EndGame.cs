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

    void Start()
    {
        
        //goals.text = GamerControler.number_GoalsLeft + "_" + GamerControler.number_GoalsRight;

        //if (GamerControler.number_GoalsLeft > GamerControler.number_GoalsRight)
        //{
        //    result.text = "You Lose";
        //}
        //else if (GamerControler.number_GoalsLeft == GamerControler.number_GoalsRight)
        //{
        //    result.text = "Draw";
        //}
        //else
        //{
        //    result.text = "You Win";
        //}
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

